namespace Cik.MagazineWeb.Init
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;
    using Autofac.Integration.WebApi;

    using AutoMapper;

    using Cik.MagazineWeb.Application.Profiles;

    public class DependencyResolverInitializer
    {
        public static void Initialize(Assembly webAssembly, IEnumerable<Assembly> relatedAssemblies)
        {
            var builder = new ContainerBuilder();

            // register all of autofac modules
            builder.RegisterAssemblyModules(relatedAssemblies.ToArray());

            // register all controllers
            builder.RegisterControllers(webAssembly);

            // register all web api controllers
            builder.RegisterApiControllers(webAssembly);

            // register all filters
            builder.RegisterFilterProvider();

            // build up the container
            var container = builder.Build();

            // register all AutoMapper profiles
            Mapper.AddProfile(new CategoryProfile());

            // register it to ASP.NET MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Create the dependency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}