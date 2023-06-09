using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Web;
using UPServiceApiClientLib.Infrastructure.Constants;

namespace UPServiceApiClientLib.Infrastructure.Helpers
{
    public class RestClient : IDisposable
    {
        private readonly WebClient webClient = new WebClient();

        public RestClient(string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                webClient.Headers[HttpRequestHeader.Authorization] = $"Bearer {accessToken}";
            }

            webClient.BaseAddress = UPServiceApiConstants.BaseUrl;
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            webClient.Encoding = Encoding.UTF8;
        }

        public T Get<T>(string apiName)
        {
            var response = webClient.DownloadString(apiName);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<T>(response);
            }

            return default(T);
        }

        public T Post<T, TT>(string apiName, TT data)
        {
            string content = JsonConvert.SerializeObject(data);
            var response = webClient.UploadString(apiName, content);

            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<T>(response);
            }

            return default(T);
        }

        public void DownloadFile(string apiName, string contentType, string downloadFilename)
        {
            using (var stream = webClient.OpenRead(apiName))
            {
                var response = HttpContext.Current.Response;

                response.Clear();
                response.ContentType = contentType;
                response.AddHeader("Content-Disposition", $"attachment; filename={downloadFilename}");
                stream.CopyTo(response.OutputStream);
                response.Flush();
                response.Close();
                response.End();
            }
        }

        public void DownloadPicture(string apiName)
        {
            DownloadFile(apiName, "image/jpg", "picture.jpg");
        }

        public void Dispose()
        {
            webClient.Dispose();
        }
    }
}
