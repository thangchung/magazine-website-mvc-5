using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Cik.PP.Web
{
    using System.Reflection;
    using System.Web.Http;

    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/fwlink/?LinkId=301868
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.RegisterRoutes(GlobalConfiguration.Configuration);
            DependencyResolverInitializer.Initialize(typeof(MvcApplication).Assembly, new List<Assembly> { typeof(CoreModule).Assembly });
            
            IdentityConfig.ConfigureIdentity();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfig.CustomizeConfig(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);    
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
