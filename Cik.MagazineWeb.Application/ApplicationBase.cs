namespace Cik.MagazineWeb.Application
{
    using System.Web.Mvc;
    using Cik.Web.Utilities;
    using Cik.Web.Utilities.Configurations;

    public abstract class ApplicationBase
    {
        protected readonly IConfigurationManager ConfigurationManager;

        protected ApplicationBase()
            : this(DependencyResolver.Current.GetService<IConfigurationManager>())
        {
        }

        protected ApplicationBase(IConfigurationManager configurationManager)
        {
            Guard.ArgumentNotNull(configurationManager, "ConfigurationManager");

            ConfigurationManager = configurationManager;
        }
    }
}