namespace Cik.PP.Web
{
    using Autofac;

    using Cik.PP.Web.Data;
    using Cik.PP.Web.Data.Repository;

    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // registering all things needed for building data context
            builder.RegisterInstance(new PlanningPokerContext()).AsSelf().SingleInstance();

            // Register the repository
            builder.RegisterType<PlanningPokerRepository>()
                   .AsImplementedInterfaces()
                   .WithParameter((pi, c) => pi.ParameterType == typeof(System.Data.Entity.DbContext),
                                  (pi, c) => c.Resolve<PlanningPokerContext>())
                   .SingleInstance();
        }
    }
}