namespace Cik.Web.Utilities.Configurations
{
    using System.Collections.Specialized;
    using System.Configuration;

    public interface IConfigurationManager
    {
        object GetSection(string sectionName);

        ConnectionStringSettingsCollection GetConnectionStrings();

        NameValueCollection GetAppSettings();

        string GetAppConfigBy(string appConfigName); 
    }
}