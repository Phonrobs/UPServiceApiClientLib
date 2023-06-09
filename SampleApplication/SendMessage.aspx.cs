using System;
using System.Threading.Tasks;
using System.Web.UI;
using UPServiceApiClientLib.Models;
using UPServiceApiClientLib.Services.AzureAD;
using UPServiceApiClientLib.Services.Messaging;

namespace SampleApplication
{
    public partial class SendMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMessagingBotId.Text = "0";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // validate
            if (string.IsNullOrEmpty(txtSubject.Text))
            {
                ltMessage.Text = "Subject has required!";
                return;
            }

            if (string.IsNullOrEmpty(txtBody.Text))
            {
                ltMessage.Text = "Body has required!";
                return;
            }

            if (string.IsNullOrEmpty(txtSendBy.Text))
            {
                ltMessage.Text = "SendBy has required!";
                return;
            }

            // send message
            // run async task in sync.
            RegisterAsyncTask(new PageAsyncTask(SendMessageAsync));
        }

        private async Task SendMessageAsync()
        {
            // first check user account exit in MSAL cache ot not?
            if (await AzureADService.IsAccountExitInCacheAsync())
            {
                // create message payload
                var payload = new MessagePayload
                {
                    Subject = txtSubject.Text,
                    Body = txtBody.Text,
                    SendTo = txtSendTo.Text,
                    Parameters = txtParameters.Text,
                    BotId = long.Parse(txtMessagingBotId.Text)
                };

                // cache exit then we shall proceed.
                // send message
                var result = await MessagingService.SendAsync(payload);

                if (result.Success)
                {
                    ltMessage.Text = "Message send complete.";
                }
                else
                {
                    ltMessage.Text = result.ErrorMessage;
                }
            }
            else
            {
                // account not exit, then re-signin again.
                AzureADService.SignIn();
            }
        }
    }
}