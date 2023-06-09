using System;
using UPServiceApiClientLib.Services.AzureAD;

namespace SampleApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check user was signedin to ADD.
            if (AzureADService.IsAuthenticated())
            {
                // yes
                ViewState["IsAuthenticated"] = "true";
            }
            else
            {
                // no
                ViewState["IsAuthenticated"] = "false";
            }
        }
    }
}