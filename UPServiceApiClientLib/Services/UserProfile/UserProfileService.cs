using UPServiceApiClientLib.Infrastructure.Constants;
using UPServiceApiClientLib.Infrastructure.Helpers;
using UPServiceApiClientLib.Services.AzureAD;

namespace UPServiceApiClientLib.Services.UserProfile
{
    public static class UserProfileService
    {
        public static UserProfileData GetUserProfile(string username)
        {
            // get access token as app
            var clientToken = AzureADClientService.GetClientCredentialToken();

            if (clientToken.Success)
            {
                // create rest client
                var apiName = string.Format(UPServiceApiConstants.ApiGetProfileUrl, username);

                using (var client = new RestClient(clientToken.AccessToken))
                {
                    return client.Get<UserProfileData>(apiName);
                }
            }

            return null;
        }

        public static void DownloadUserPhoto(string username)
        {
            // get access token as app
            var clientToken = AzureADClientService.GetClientCredentialToken();

            if (clientToken.Success)
            {
                // create rest client
                var apiName = string.Format(UPServiceApiConstants.ApiGetProfilePhotoUrl, username);

                using (var client = new RestClient(clientToken.AccessToken))
                {
                    client.DownloadPicture(apiName);
                }
            }
        }
    }
}
