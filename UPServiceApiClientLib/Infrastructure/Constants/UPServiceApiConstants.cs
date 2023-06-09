namespace UPServiceApiClientLib.Infrastructure.Constants
{
    public class UPServiceApiConstants
    {
        public const string BackendScope = "api://ad716737-aefd-4892-a67d-f806f3829162/.default";
        public const string BaseUrl = "https://app.up.ac.th/smartup/api/";

        public const string ApiGetProfileUrl = BaseUrl + "profile/users/{0}";
        public const string ApiGetProfilePhotoUrl = BaseUrl + "profile/users/{0}/photo";

        public const string ApiSendMessage = UPServiceApiConstants.BaseUrl + "messaging/send";
        public const string ApiSendMessageToBot = UPServiceApiConstants.BaseUrl + "messaging/sendtobot";
        public const string CONTENT_TYPE_TEXT = "text";

        public const string ApiAppTokenValidate = UPServiceApiConstants.BaseUrl + "apps/{0}/validate?token={1}";
    }
}
