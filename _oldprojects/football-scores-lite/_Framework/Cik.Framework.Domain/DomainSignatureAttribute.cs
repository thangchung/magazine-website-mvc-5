namespace Cik.Framework.Domain
{
    using System;

    /// <summary>
    ///     Facilitates indicating which property(s) describe the unique signature of an 
    ///     entity.  See EntityWithTypedId.GetTypeSpecificSignatureProperties() for when this is leveraged.
    /// </summary>
    /// <remarks>
    ///     This is intended for use with <see cref = "EntityWithTypedId{TId}" />.
    /// </remarks>
    [Serializable]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DomainSignatureAttribute : Attribute { }
}