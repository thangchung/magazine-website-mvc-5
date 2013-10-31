namespace Cik.Framework.Domain
{
    using System;
    using System.Collections.Generic;

    public abstract class ComparableValueObject : ValueObject, IComparable
    {
        protected abstract IEnumerable<IComparable> GetComparableComponents();

        protected IComparable AsNonGenericComparable<T>(IComparable<T> comparable)
        {
            return new NonGenericComparable<T>(comparable);
        }

        class NonGenericComparable<T> : IComparable
        {
            public NonGenericComparable(IComparable<T> comparable)
            {
                this.comparable = comparable;
            }

            readonly IComparable<T> comparable;

            public int CompareTo(object obj)
            {
                if (object.ReferenceEquals(this.comparable, obj)) return 0;
                if (object.ReferenceEquals(null, obj))
                    throw new ArgumentNullException();
                return this.comparable.CompareTo((T)obj);
            }
        }

        protected int CompareTo(ComparableValueObject other)
        {
            using (var thisComponents = GetComparableComponents().GetEnumerator())
            using (var otherComponents = other.GetComparableComponents().GetEnumerator())
            {
                while (true)
                {
                    var x = thisComponents.MoveNext();
                    var y = otherComponents.MoveNext();
                    if (x != y)
                        throw new InvalidOperationException();
                    if (x)
                    {
                        var c = thisComponents.Current.CompareTo(otherComponents.Current);
                        if (c != 0)
                            return c;
                    }
                    else
                    {
                        break;
                    }
                }
                return 0;
            }
        }

        public int CompareTo(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return 0;
            if (object.ReferenceEquals(null, obj)) return 1;

            if (GetType() != obj.GetType())
                throw new InvalidOperationException();

            return CompareTo(obj as ComparableValueObject);
        }
    }

    public abstract class ComparableValueObject<T> : ComparableValueObject, IComparable<T>
        where T : ComparableValueObject<T>
    {
        public int CompareTo(T other)
        {
            return base.CompareTo(other);
        }
    }
}