using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using UPServiceApiClientLib.Infrastructure.Constants;

namespace UPServiceApiClientLib.Services.AzureAD
{
    public static class AzureADClientService
    {
        private static string GetAuthorizeCodeUrl()
        {
            var options = AppService.AadOptions;
            var scopes = HttpContext.Current.Server.UrlEncode(AzureADConstants.BasicScopes);

            return $"https://login.microsoftonline.com/{options.TenantId}/oauth2/v2.0/authorize?client_id={options.ClientId}&response_type=code&redirect_uri={HttpContext.Current.Server.UrlEncode(options.RedirectUri)}&response_mode=query&scope={scopes}&state=12345";
        }

        private static string GetAccessTokenUrl()
        {
            var options = AppService.AadOptions;

            return $"https://login.microsoftonline.com/{options.TenantId}/oauth2/v2.0/token";
        }

        private static bool HasError()
        {
            return !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["error"]);
        }

        private static bool HasCancel()
        {
            var code = GetCode();
            return !string.IsNullOrEmpty(code) && code == "cancel";
        }

        private static bool HasCode()
        {
            var code = GetCode();
            return !string.IsNullOrEmpty(code);
        }

        private static string GetCode()
        {
            return HttpContext.Current.Request.QueryString["code"];
        }

        private static string GetErrorMessage()
        {
            return HttpContext.Current.Request.QueryString["error_description"];
        }

        /// <summary>
        /// Signin to Azure AD with OAuth2
        /// </summary>
        public static SignInCallbackResult SignIn()
        {
            // check for callback data
            if (HasCode())
            {
                if (HasCancel())
                {
                    return SignInCallbackResult.ErrorResult("cancel");
                }
                else
                {
                    return ProcessSigninCallbackResult();
                }
            }
            else if (HasError())
            {
                return SignInCallbackResult.ErrorResult(GetErrorMessage());
            }
            else
            {
                var url = GetAuthorizeCodeUrl();
                HttpContext.Current.Response.Redirect(url);

                return SignInCallbackResult.ErrorResult("redirect");
            }
        }

        /// <summary>
        /// Handler signin callback result from Azure AD
        /// </summary>
        public static SignInCallbackResult SignInCallback()
        {
            // check for callback data
            if (HasCode())
            {
                if (HasCancel())
                {
                    return SignInCallbackResult.ErrorResult("cancel");
                }
                else
                {
                    return ProcessSigninCallbackResult();
                }
            }
            else if (HasError())
            {
                return SignInCallbackResult.ErrorResult(GetErrorMessage());
            }
            else
            {
                return SignInCallbackResult.SuccessResult();
            }
        }

        public static string CurrentUserAccessToken { get => HttpContext.Current.Session["access_token"]?.ToString(); }

        public static DateTime? CurrentUserTokenExpireDate { get => (DateTime?)HttpContext.Current.Session["expire_date"]; }

        public static string CurrentUsername { get => HttpContext.Current.Session["username"]?.ToString(); }

        private static SignInCallbackResult ProcessSigninCallbackResult()
        {
            // get auth code
            var code = GetCode();

            // create get access token request
            var options = AppService.AadOptions;

            var formData = new NameValueCollection();
            formData.Add("client_id", options.ClientId);
            formData.Add("scope", AzureADConstants.BasicScopes);
            formData.Add("code", code);
            formData.Add("redirect_uri", options.RedirectUri);
            formData.Add("grant_type", "authorization_code");
            formData.Add("client_secret", options.ClientSecret);

            var url = GetAccessTokenUrl();

            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                byte[] responseBytes = webClient.UploadValues(url, "POST", formData);
                string responseString = Encoding.UTF8.GetString(responseBytes);

                var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseString);

                if (!string.IsNullOrEmpty(tokenResponse.AccessToken) && !string.IsNullOrEmpty(tokenResponse.IdToken))
                {
                    // extract user info from id_token
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadJwtToken(tokenResponse.IdToken);
                    var username = jsonToken.Claims.FirstOrDefault(claim => claim.Type == AzureADConstants.UsernameClaimType)?.Value;

                    if (string.IsNullOrEmpty(username))
                    {
                        return SignInCallbackResult.ErrorResult("invalid_id_token");
                    }

                    // save tokens in session
                    HttpContext.Current.Session["access_token"] = tokenResponse.AccessToken;
                    HttpContext.Current.Session["expire_date"] = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn - 10);
                    HttpContext.Current.Session["username"] = username;

                    return SignInCallbackResult.SuccessResult();
                }
                else if (!string.IsNullOrEmpty(tokenResponse.Error))
                {
                    return SignInCallbackResult.ErrorResult(tokenResponse.ErrorDescription);
                }
                else
                {
                    return SignInCallbackResult.ErrorResult("unknow_error");
                }
            }
        }

        public static void SignOut()
        {
            HttpContext.Current.Session.Remove("access_token");
            HttpContext.Current.Session.Remove("expire_date");
            HttpContext.Current.Session.Remove("username");
        }

        public static ClientCredentialToken GetClientCredentialToken()
        {
            // create get access token request
            var options = AppService.AadOptions;

            var formData = new NameValueCollection();
            formData.Add("client_id", options.ClientId);
            formData.Add("scope", AppService.ServiceScope);
            formData.Add("client_secret", options.ClientSecret);
            formData.Add("grant_type", "client_credentials");

            var url = GetAccessTokenUrl();

            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                byte[] responseBytes = webClient.UploadValues(url, "POST", formData);
                string responseString = Encoding.UTF8.GetString(responseBytes);

                var tokenResponse = JsonConvert.DeserializeObject<ClientCredentialToken>(responseString);

                if (!string.IsNullOrEmpty(tokenResponse.AccessToken))
                {
                    // save tokens in session
                    tokenResponse.Success = true;
                    tokenResponse.ExpireDate = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn - 10);
                }

                return tokenResponse;
            }

        }
    }
}

