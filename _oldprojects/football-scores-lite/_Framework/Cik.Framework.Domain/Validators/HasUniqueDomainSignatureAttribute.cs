namespace Cik.Framework.Domain.Validators
{
    using System;
    using System.ComponentModel.DataAnnotations;
    // This is needed for the DependencyResolver...wish they would've just used Common Service Locator!
    using System.Web.Mvc;

    using Cik.Framework.Domain.DataInterfaces;

    /// <summary>
    /// Due to the fact that .NET does not support generic attributes, this only works for entity 
    /// types having an Id of type int.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    sealed public class HasUniqueDomainSignatureAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return null;

            var entityToValidate = value as IEntityWithTypedId<int>;

            if (entityToValidate == null)
                throw new InvalidOperationException(
                    "This validator must be used at the class level of an IEntityWithTypedId<int>. " +
                    "The type you provided was " + value.GetType());

            var duplicateChecker = DependencyResolver.Current.GetService<IEntityDuplicateChecker>();

            if (duplicateChecker == null)
                throw new TypeLoadException("IEntityDuplicateChecker has not been registered with IoC");

            return duplicateChecker.DoesDuplicateExistWithTypedIdOf(entityToValidate) ? new ValidationResult(String.Empty) : null;
        }
    }
}