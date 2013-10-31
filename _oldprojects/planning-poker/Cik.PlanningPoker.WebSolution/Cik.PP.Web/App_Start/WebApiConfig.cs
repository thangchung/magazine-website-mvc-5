namespace Cik.PP.Web
{
    using System.Web.Http;

    public class WebApiConfig
    {
        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "StoryByGameApi",
                routeTemplate: "api/v1/games/{gameid}/stories/{id}",
                defaults: new { controller = "stories", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "StoryApi",
                routeTemplate: "api/v1/stories/{id}",
                defaults: new { controller = "stories", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "GameApi",
                routeTemplate: "api/v1/games/{id}",
                defaults: new { controller = "games", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=301869.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}