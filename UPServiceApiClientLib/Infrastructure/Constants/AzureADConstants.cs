namespace UPServiceApiClientLib.Infrastructure.Constants
{
    public class AzureADConstants
    {
        public const string DefaultTenantId = "d7cbbb08-47a3-4bd7-8347-5018f2744cfb";
        public const string DefaultInstance = "https://login.microsoftonline.com";
        public const string BasicScopes = "offline_access openid profile https://graph.microsoft.com/user.read";
        public const string UsernameClaimType = "preferred_username";
    }
}
