using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cik.PP.Web.Controllers
{
    using System.Web;

    using Cik.PP.Web.Data;

    [Authorize]
    public class GamesController : ApiController
    {
        private readonly IPlanningPokerRepository _repository;

        public GamesController(IPlanningPokerRepository repository)
        {
            _repository = repository;
        }
       
        public IEnumerable<Game> Get()
        {
            return _repository.GetGamesIncludeAll().OrderByDescending(x => x.Created).ToList();
        }
        
        public Game Get(Guid id)
        {
            return _repository.GetGamesIncludeAll().First(x=>x.Id == id);
        }
        
        public HttpResponseMessage Post([FromBody]Game value)
        {
            value.CreatedBy = HttpContext.Current.User.Identity.Name;
            var newGame = _repository.SaveGame(value);

            if (newGame.Id.ToString() != string.Empty)
            {
                return Request.CreateResponse(HttpStatusCode.Created, newGame);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public HttpResponseMessage Put([FromBody]Game game)
        {
            var updatedGame = _repository.UpdateGame(game);

            return updatedGame.Modified <= game.Modified 
                ? new HttpResponseMessage(HttpStatusCode.NotModified) 
                : Request.CreateResponse(HttpStatusCode.OK, updatedGame);
        }

        public HttpResponseMessage Delete(Guid id)
        {
            var isSucceed = _repository.DeleteGame(id);
            return isSucceed ? new HttpResponseMessage(HttpStatusCode.NoContent) : Request.CreateResponse(HttpStatusCode.OK, isSucceed);
        }
    }
}