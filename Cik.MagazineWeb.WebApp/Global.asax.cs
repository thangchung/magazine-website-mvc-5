namespace Cik.MagazineWeb.WebApp
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Reflection;

    using Cik.MagazineWeb.Init;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            var webAssembly = typeof(MvcApplication).Assembly;
            var relatedAssemblies = new List<Assembly> { typeof(CoreModule).Assembly };

            DependencyResolverInitializer.Initialize(webAssembly, relatedAssemblies);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
