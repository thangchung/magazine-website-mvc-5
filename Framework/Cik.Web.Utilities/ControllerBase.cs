namespace Cik.Web.Utilities
{
    using System.Web.Mvc;

    using Cik.Web.Utilities.Configurations;
    using Cik.Web.Utilities.Extensions;

    public class ControllerBase : Controller
    {
         protected readonly IConfigurationManager ConfigurationManager;

        protected ControllerBase()
            : this(DependencyResolver.Current.GetService<IConfigurationManager>())
        {
        }

        protected ControllerBase(IConfigurationManager configurationManager)
        {
            Guard.ArgumentNotNull(configurationManager, "ConfigurationManager");

            this.ConfigurationManager = configurationManager;
        }

        protected int PageSize
        {

            get { return this.ConfigurationManager.GetAppConfigBy("PageSize").ConvertToInteger(); }
        }

        public int NumOfItemOnHomePage
        {
            get { return this.ConfigurationManager.GetAppConfigBy("NumOfItemOnHomePage").ConvertToInteger(); }
        }
    }
}