using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api
{
    public class HttpUrlCaller
    {
        private const string ContentType = "application/json";

        public async static Task<HttpUrlResponse> GetResponse(HttpUrlRequest request)
        {
            var absoluteUri = request.RequestUrl;

            var body = request.GetQueryString();
            var method = request.Method;
            var url = absoluteUri.ToString();

            var publicKey = CoinpaymentsSettings.Default.PublicKey;
            var privateKey = CoinpaymentsSettings.Default.PrivateKey;

            var signature = CryptoUtil.CalcSignature(body, privateKey);

            using (var httpClient = new HttpClient())
            {
                //httpClient.Timeout = TimeSpan.FromSeconds(300);
                HttpResponseMessage response;

                httpClient.DefaultRequestHeaders.Add("HMAC", signature);

                switch (method)
                {
                    case "GET":
                        response = await httpClient.GetAsync(absoluteUri);
                        break;
                    case "POST":
                        var requestBody = new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded");
                        //var requestBody = new StringContent(body);
                        response = await httpClient.PostAsync(absoluteUri, requestBody);
                        break;
                    default:
                        throw new NotImplementedException("The supplied HTTP method is not supported: " + method ?? "(null)");
                }


                var contentBody = await response.Content.ReadAsStringAsync();
                var headers = response.Headers.AsEnumerable();
                var statusCode = response.StatusCode;
                var isSuccess = response.IsSuccessStatusCode;

                var genericExchangeResponse = new HttpUrlResponse(statusCode, isSuccess, headers, contentBody, absoluteUri, body);
                return genericExchangeResponse;
            }
        }

    }
}
