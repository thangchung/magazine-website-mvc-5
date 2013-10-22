namespace Cik.MagazineWeb.DomainModel
{
    using System.Linq;

    public interface IMagazineWebRepository
    {
        IQueryable<Category> GetAllCategories();

        IQueryable<Item> GetAllItems();
    }
}