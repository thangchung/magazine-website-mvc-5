using System.Collections.Generic;
using System.Web.Http;

namespace Cik.PP.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;

    using Cik.PP.Web.Data;

    [Authorize]
    public class StoriesController : ApiController
    {
        private readonly IPlanningPokerRepository _repository;

        public StoriesController(IPlanningPokerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Story> Get(Guid gameid)
        {
            return null;
        }

        public HttpResponseMessage Post([FromBody]Story value)
        {
            value.CreatedBy = HttpContext.Current.User.Identity.Name;
            var newStory = _repository.SaveStory(value);

            if (newStory.Id.ToString() != string.Empty)
            {
                return Request.CreateResponse(HttpStatusCode.Created, newStory);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}