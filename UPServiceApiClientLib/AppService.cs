using System.Configuration;
using UPServiceApiClientLib.Infrastructure.Constants;
using UPServiceApiClientLib.Infrastructure.Options;

namespace UPServiceApiClientLib
{
    public static class AppService
    {
        private static int _appId;
        private static AzureADOptions _aadOptions;
        private static string _serviceScope;

        public static AzureADOptions AadOptions
        {
            get => _aadOptions;
        }

        public static int AppId
        {
            get => _appId;
        }

        public static string ServiceScope
        {
            get => _serviceScope;
        }

        public static void Init()
        {
            _aadOptions = new AzureADOptions
            {
                ClientId = ConfigurationManager.AppSettings["ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["ClientSecret"],
                RedirectUri = ConfigurationManager.AppSettings["RedirectUri"],
                TenantId = ConfigurationManager.AppSettings["TenantId"]
            };

            if (string.IsNullOrEmpty(_aadOptions.TenantId))
            {
                _aadOptions.TenantId = AzureADConstants.DefaultTenantId;
            }

            _appId = int.Parse(ConfigurationManager.AppSettings["AppId"]);

            _serviceScope = ConfigurationManager.AppSettings["ServiceScope"];

            if(string.IsNullOrEmpty(_serviceScope))
            {
                _serviceScope = UPServiceApiConstants.BackendScope;
            }
        }
    }
}
