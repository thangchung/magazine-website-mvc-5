namespace Cik.PP.Web.Data
{
    using System;
    using System.Linq;

    public interface IPlanningPokerRepository
    {
        IQueryable<Game> GetGames();

        IQueryable<Game> GetGamesIncludeAll();

        Game SaveGame(Game game);

        Game UpdateGame(Game value);

        bool DeleteGame(Guid id);

        Story SaveStory(Story story);
    }
}