namespace Cik.Framework.EntityFrameworkProvider
{
    using System;

    using Cik.Framework.Domain;
    using Cik.Framework.Domain.DataInterfaces;

    public class EntityDuplicateChecker : IEntityDuplicateChecker
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Provides a behavior specific repository for checking if a duplicate exists of an existing entity.
        /// </summary>
        public bool DoesDuplicateExistWithTypedIdOf<TId>(IEntityWithTypedId<TId> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return false;
        }

        #endregion
    }
}