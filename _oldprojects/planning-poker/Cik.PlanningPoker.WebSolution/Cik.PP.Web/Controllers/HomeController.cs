using System.Web.Mvc;

namespace Cik.PP.Web.Controllers
{
    using System.Linq;

    using Cik.PP.Web.Data;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPlanningPokerRepository _repository;
        public HomeController(IPlanningPokerRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var temps = _repository.GetGamesIncludeAll().ToList();

            return View();
        }
    }
}