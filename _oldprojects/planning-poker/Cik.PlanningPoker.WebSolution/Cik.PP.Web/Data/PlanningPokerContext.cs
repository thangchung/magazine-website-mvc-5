namespace Cik.PP.Web.Data
{
    using System.Data.Entity;

    public class PlanningPokerContext : DbContext
    {
        public PlanningPokerContext()
            : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<PlanningPokerContext, PlanningPokerMigrationsConfiguration>()
                );
        }

        public DbSet<Game> Games { get; set; } // root aggregate
    }
}