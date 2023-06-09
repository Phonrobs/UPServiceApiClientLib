using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.UI;
using UPServiceApiClientLib.Services.AppSSO;
using UPServiceApiClientLib.Services.AzureAD;

namespace SampleApplication
{
    public partial class SssoSignin : System.Web.UI.Page
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
                // load profile from UPSmartApiService.
                var result = await AppSSOService.ValidateAndGetUserProfileAsync();

                if(!result.Success)
                {
                    // invalid token
                    Response.Redirect($"~/Error.aspx?message={result.ErrorMessage}");
                }

                // profile loading successful, you should save its in Session or do anything you want.
                // show profile
                var profile = result.UserProfile;

                ViewState["Username"] = profile.Username;
                ViewState["DisplayName"] = profile.DisplayName;
                ViewState["Email"] = profile.Email;
                ViewState["OtherEmails"] = profile.OtherEmails;
                ViewState["BusinessPhones"] = profile.BusinessPhones;
                ViewState["MobilePhone"] = profile.MobilePhone;
                ViewState["JobTitle"] = profile.JobTitle;
                ViewState["FacultyName"] = profile.FacultyName;
                ViewState["PersonCode"] = profile.PersonCode;
                ViewState["PersonType"] = profile.PersonType;
            }
            else
            {
                // account not exit, then re-signin again.
                AzureADService.SignIn();
            }
        }
    }
}