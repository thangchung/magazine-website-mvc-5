using System;
using System.Linq;

namespace Cik.PP.Web.Data
{
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;
    using System.Web;

    public class PlanningPokerMigrationsConfiguration : DbMigrationsConfiguration<PlanningPokerContext>
    {
        public PlanningPokerMigrationsConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PlanningPokerContext context)
        {
            base.Seed(context);

#if DEBUG
            if (!context.Games.Any())
            {
                var game = new Game
                           {
                               Id = Guid.NewGuid(),
                               Name = "game 01",
                               Description = "description for game 01",
                               CreatedBy = HttpContext.Current.User.Identity.Name,
                               Created = DateTime.UtcNow,
                               Stories = new Collection<Story>
                                         {
                                             new Story
                                             {
                                                 Id = Guid.NewGuid(),
                                                 Role = "User",
                                                 Purpose = "register the user name and input the password",
                                                 Note = "note",
                                                 Result = "I can log in to the system",
                                                 CreatedBy = HttpContext.Current.User.Identity.Name,
                                                 Created = DateTime.UtcNow
                                             }
                                         }
                           };

                context.Games.Add(game);

                var otherGame = new Game
                {
                    Id = Guid.NewGuid(),
                    Name = "game 02",
                    Description = "description for game 02",
                    CreatedBy = HttpContext.Current.User.Identity.Name,
                    Created = DateTime.UtcNow,
                    Stories = new Collection<Story>
                                         {
                                             new Story
                                             {
                                                 Id = Guid.NewGuid(),
                                                 Role = "User",
                                                 Purpose = "register the user name and input the password",
                                                 Note = "note",
                                                 Result = "I can log in to the system",
                                                 CreatedBy = HttpContext.Current.User.Identity.Name,
                                                 Created = DateTime.UtcNow
                                             }
                                         }
                };

                context.Games.Add(otherGame);

                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    // TODO: write log here
                    var message = ex.Message;
                }
            }
#endif
        }
    }
}
