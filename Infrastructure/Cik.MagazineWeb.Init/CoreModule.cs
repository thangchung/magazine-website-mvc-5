namespace Cik.MagazineWeb.Init
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Autofac;

    using Cik.MagazineWeb.Application;
    using Cik.MagazineWeb.Application.Services.Impl;
    using Cik.MagazineWeb.EntityFrameworkProvider;
    using Cik.Web.Utilities.Configurations.Impl;
    using Cik.Web.Utilities.Encyption.Impl;

    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // registering all things needed for building data context
            builder.RegisterInstance(new MagazineWebContext()).AsSelf().SingleInstance();

            // Register the repository
            builder.RegisterType<MagazineWebRepository>()
                   .AsImplementedInterfaces()
                   .WithParameter((pi, c) => pi.ParameterType == typeof(IMagazineWebContext),
                                  (pi, c) => c.Resolve<MagazineWebContext>())
                   .SingleInstance();

            //// registering all things needed for building data context
            //builder.RegisterInstance(new MagazineWebContext())
            //       .AsSelf().SingleInstance();

            //builder.RegisterGeneric(typeof(Repository<>))
            //       .As(typeof(IRepository<>))
            //       .WithParameter((pi, c) => pi.ParameterType == typeof(System.Data.Entity.DbContext),
            //                      (pi, c) => c.Resolve<CoreDbContext>());

            // registering all utility objects
            builder.RegisterType<SimpleEncryptor>()
                   .AsImplementedInterfaces();
            
            builder.RegisterType<ConfigurationManager>()
                   .AsImplementedInterfaces();

            // registering all application instances
            builder.RegisterType<MagazineApplication>()
                   .AsImplementedInterfaces();

            // registering all services
            builder.RegisterType<ItemSummaryService>()
                   .AsImplementedInterfaces();

            builder.RegisterType<CategoryService>()
                   .AsImplementedInterfaces();
        }
    }
}