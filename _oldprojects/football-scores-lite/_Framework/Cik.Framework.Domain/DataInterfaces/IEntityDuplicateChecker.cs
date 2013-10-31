namespace Cik.Framework.Domain.DataInterfaces
{
    public interface IEntityDuplicateChecker
    {
        bool DoesDuplicateExistWithTypedIdOf<TId>(IEntityWithTypedId<TId> entity);
    }
}
