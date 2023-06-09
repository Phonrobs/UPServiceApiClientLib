using System;
using System.Threading.Tasks;
using System.Web.UI;
using UPServiceApiClientLib.Services.AzureAD;
using UPServiceApiClientLib.Services.UserProfile;

namespace SampleApplication
{
    public partial class ProfilePhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // run async task in sync page_load.
            RegisterAsyncTask(new PageAsyncTask(PageLoadAsync));
        }

        private async Task PageLoadAsync()
        {
            // first check user account exit in MSAL cache ot not?
            if (await AzureADService.IsAccountExitInCacheAsync())
            {
                // cache exit then we shall proceed.
                // download user photo from UPSmartApiService.
                await UserProfileService.DownloadCurrentUserPhotoAsync();
            }
            else
            {
                // account not exit, then re-signin again.
                AzureADService.SignIn();
            }
        }
    }
}