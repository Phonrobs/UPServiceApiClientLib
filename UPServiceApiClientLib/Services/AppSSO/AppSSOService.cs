using System.Web;
using UPServiceApiClientLib.Infrastructure.Constants;
using UPServiceApiClientLib.Infrastructure.Helpers;
using UPServiceApiClientLib.Services.AzureAD;

namespace UPServiceApiClientLib.Services.AppSSO
{
    public class AppSSOService
    {
        public static AppValidateResult ValidateAndGetUserProfile()
        {
            // get parameter pass from source app
            var appId = AppService.AppId;
            var token = HttpContext.Current.Request.QueryString["token"];

            return ValidateAndGetUserProfile(appId, token);
        }

        public static AppValidateResult ValidateAndGetUserProfile(int appId, string token)
        {
            // get access token as app
            var clientToken = AzureADClientService.GetClientCredentialToken();

            if (clientToken.Success)
            {
                // create rest client
                var apiName = string.Format(UPServiceApiConstants.ApiAppTokenValidate, appId, token);

                using (var client = new RestClient(clientToken.AccessToken))
                {
                    return client.Get<AppValidateResult>(apiName);
                }
            }

            return new AppValidateResult
            {
                ErrorMessage = "Unauthorized"
            };
        }
    }
}
