using Newtonsoft.Json;
using System;

namespace UPServiceApiClientLib.Services.AzureAD
{
    public class ClientCredentialToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }

        public DateTime? ExpireDate;
        public bool Success;
    }
}
