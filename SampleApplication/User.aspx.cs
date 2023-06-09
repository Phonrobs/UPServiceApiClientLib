using System;
using UPServiceApiClientLib.Services.AzureAD;

namespace SampleApplication
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check user was signedin?
            if (AzureADService.IsAuthenticated())
            {
                // yes, then get current username from id_token claim (cookie).
                ViewState["CurrentUsername"] = AzureADService.GetCurrentUsername();
            }
            else
            {
                // no, then signin user again.
                Response.Redirect("~/Signin.aspx");
            }
        }
    }
}