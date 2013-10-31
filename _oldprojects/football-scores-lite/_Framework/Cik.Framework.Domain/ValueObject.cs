namespace Cik.Framework.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class ValueObject
    {
        /// <summary>
        /// When overriden in a derived class, returns all components of a value objects which constitute its identity.
        /// </summary>
        /// <returns>An ordered list of equality components.</returns>
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (ReferenceEquals(null, obj)) return false;
            if (this.GetType() != obj.GetType()) return false;
            var vo = obj as ValueObject;
            return GetEqualityComponents().SequenceEqual(vo.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(GetEqualityComponents());
        }
        private static int CombineHashCodes(IEnumerable<object> objs)
        {
            unchecked
            {
                return objs.Aggregate(17, (current, obj) => current * 23 + (obj != null ? obj.GetHashCode() : 0));
            }
        }
    }
}