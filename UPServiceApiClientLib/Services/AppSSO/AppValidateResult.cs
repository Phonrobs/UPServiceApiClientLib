using UPServiceApiClientLib.Services.UserProfile;

namespace UPServiceApiClientLib.Services.AppSSO
{
    public class AppValidateResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public UserProfileData UserProfile { get; set; }
    }
}
