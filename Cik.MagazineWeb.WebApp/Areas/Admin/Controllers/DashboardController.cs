namespace Cik.MagazineWeb.WebApp.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using ControllerBase = Cik.Web.Utilities.ControllerBase;

    [Authorize]
    public class DashboardController : ControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}