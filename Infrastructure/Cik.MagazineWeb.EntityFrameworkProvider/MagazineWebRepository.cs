namespace Cik.MagazineWeb.EntityFrameworkProvider
{
    using System.Linq;

    using Cik.MagazineWeb.DomainModel;
    using Cik.Web.Utilities;

    public class MagazineWebRepository : IMagazineWebRepository
    {
        private readonly IMagazineWebContext _dbContext;

        public MagazineWebRepository(IMagazineWebContext dbContext)
        {
            Guard.ArgumentNotNull(dbContext, "DbContext");

            _dbContext = dbContext;
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _dbContext.Categories;
        }

        public IQueryable<Item> GetAllItems()
        {
            return _dbContext.Items;
        } 
    }
}