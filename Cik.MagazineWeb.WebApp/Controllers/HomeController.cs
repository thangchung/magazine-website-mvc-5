using System.Web.Mvc;

namespace Cik.MagazineWeb.WebApp.Controllers
{
    using Cik.MagazineWeb.Application;
    using Cik.Web.Utilities;

    public class HomeController : ControllerBase
    {
        private readonly IMagazineApplication _magazineApplication;

        public HomeController(IMagazineApplication magazineApplication)
        {
            Guard.ArgumentNotNull(magazineApplication, "MagazineApplication");

            _magazineApplication = magazineApplication;
        }

        public ActionResult Index()
        {
            var viewModel = _magazineApplication.BuildHomePageViewModel(NumOfItemOnHomePage);
            return View(viewModel);
        }
      
        [Route("Home/Details/{title?}/{categoryId:int}/{itemId:int}")]
        public ActionResult Details(int categoryId, int itemId, string title = null)
        {
            var viewModel = _magazineApplication.BuildItemDetailsViewModel(categoryId, itemId);

            return View(viewModel);
        }

        [Route("Home/Category/{name}/{id:int}")]
        public ActionResult Category(string name, int id)
        {
            var viewModel = _magazineApplication.BuildCategoryPageViewModel(id);
            return View(viewModel);
        }
    }
}