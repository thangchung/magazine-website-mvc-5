namespace Cik.Web.Utilities
{
    using System.Web.Http;
    using System.Web.Mvc;

    using Cik.Web.Utilities.Configurations;
    using Cik.Web.Utilities.Extensions;

    public class ApiControllerBase : ApiController
    {
        protected readonly IConfigurationManager ConfigurationManager;

        protected ApiControllerBase()
            : this(DependencyResolver.Current.GetService<IConfigurationManager>())
        {
        }

        protected ApiControllerBase(IConfigurationManager configurationManager)
        {
            Guard.ArgumentNotNull(configurationManager, "ConfigurationManager");

            this.ConfigurationManager = configurationManager;
        }

        protected int PageSize
        {

            get { return this.ConfigurationManager.GetAppConfigBy("PageSize").ConvertToInteger(); }
        }
    }
}