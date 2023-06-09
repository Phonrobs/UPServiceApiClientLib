using System;
using UPServiceApiClientLib.Services.AzureAD;

namespace SampleApplication
{
    public partial class Signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // show Azure AD login screen.
            AzureADService.SignIn();
        }
    }
}