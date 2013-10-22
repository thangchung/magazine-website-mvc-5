using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cik.MagazineWeb.WebApp.Startup))]
namespace Cik.MagazineWeb.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
