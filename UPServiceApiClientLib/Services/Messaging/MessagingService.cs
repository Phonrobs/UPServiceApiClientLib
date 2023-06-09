using UPServiceApiClientLib.Infrastructure.Constants;
using UPServiceApiClientLib.Infrastructure.Helpers;
using UPServiceApiClientLib.Models;
using UPServiceApiClientLib.Services.AzureAD;

namespace UPServiceApiClientLib.Services.Messaging
{
    public class MessagingService
    {
        public static ApiResult Send(MessagePayload payload)
        {
            // get access token as app
            var clientToken = AzureADClientService.GetClientCredentialToken();

            if (clientToken.Success)
            {
                // create rest client
                var apiName = UPServiceApiConstants.ApiSendMessage;

                using (var client = new RestClient(clientToken.AccessToken))
                {
                    return client.Post<ApiResult, MessagePayload>(apiName, payload);
                }
            }

            return new ApiResult
            {
                ErrorMessage = "Unauthorized"
            };
        }

        public static ApiResult SendToBot(MessageToBotPayload payload)
        {
            // get access token as app
            var clientToken = AzureADClientService.GetClientCredentialToken();

            if (clientToken.Success)
            {
                // create rest client
                var apiName = UPServiceApiConstants.ApiSendMessageToBot;

                using (var client = new RestClient(clientToken.AccessToken))
                {
                    return client.Post<ApiResult, MessageToBotPayload>(apiName, payload);
                }
            }

            return new ApiResult
            {
                ErrorMessage = "Unauthorized"
            };
        }
    }
}
