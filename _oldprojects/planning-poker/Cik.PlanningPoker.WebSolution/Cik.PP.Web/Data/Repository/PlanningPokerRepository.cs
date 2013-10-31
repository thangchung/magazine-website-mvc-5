namespace Cik.PP.Web.Data.Repository
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class PlanningPokerRepository : IPlanningPokerRepository
    {
        private readonly PlanningPokerContext _dbContext;
        public PlanningPokerRepository(PlanningPokerContext context)
        {
            _dbContext = context;
        }

        public IQueryable<Game> GetGames()
        {
            return _dbContext.Games;
        }

        public IQueryable<Game> GetGamesIncludeAll()
        {
            return _dbContext.Games.Include("Stories");
        }

        public Game SaveGame(Game game)
        {
            game.Id = Guid.NewGuid();
            game.Created = DateTime.UtcNow;
            var newGame = _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            return newGame;
        }

        public Game UpdateGame(Game game)
        {
            var originalGame = GetGames().FirstOrDefault(x => x.Id == game.Id);
            if (originalGame != null)
            {
                _dbContext.Entry(originalGame).CurrentValues.SetValues(game);
                _dbContext.SaveChanges();
            }

            return originalGame;
        }

        public bool DeleteGame(Guid id)
        {
            var originalGame = GetGames().FirstOrDefault(x => x.Id == id);
            _dbContext.Games.Remove(originalGame);
            _dbContext.SaveChanges();
            return true;
        }

        public Story SaveStory(Story story)
        {
            var game = _dbContext.Games.FirstOrDefault(x => x.Id == story.GameId);
            if(game == null)
                throw new NullReferenceException(string.Format("Could not find any game with Id = {0}", story.GameId));
            if(game.Stories == null) game.Stories = new Collection<Story>();
            story.Id = Guid.NewGuid();
            story.Created = DateTime.UtcNow;
            game.Stories.Add(story);
            _dbContext.SaveChanges();

            return story;
        }
    }
}