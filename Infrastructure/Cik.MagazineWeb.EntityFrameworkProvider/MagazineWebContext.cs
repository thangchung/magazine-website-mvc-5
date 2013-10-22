namespace Cik.MagazineWeb.EntityFrameworkProvider
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Cik.MagazineWeb.DomainModel;

    public class MagazineWebContext : DbContext, IMagazineWebContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        public MagazineWebContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MagazineWebContext, MagazineWebMigrationsConfiguration>()
                );
        }
    }

    public interface IMagazineWebContext : IObjectContextAdapter
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Item> Items { get; set; }
    }
}