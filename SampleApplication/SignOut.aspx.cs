using System;
using UPServiceApiClientLib.Services.AzureAD;

namespace SampleApplication
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // signout current user and rturn to home page (Default.aspx).
            AzureADService.SignOut();
        }
    }
}