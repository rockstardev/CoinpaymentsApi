using Coinpayments.Api.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Coinpayments.Api
{
    public class HttpUrlRequest
    {
        public HttpUrlRequest(object param, string method = "POST", string url = "https://www.coinpayments.net/api.php")
        {
            Method = method;
            RequestUrl = url;

            if (param != null)
            {
                RequestBody = JsonSerializer.SerializeToString(param);
                if (param is CreateMassWithdrawalRequest)
                {
                    var casted = param as CreateMassWithdrawalRequest;
                    RequestBody = casted.GetRequestBody();
                }
            }
        }

        public string Method { get; set; }
        public string RequestUrl { get; set; }

        public string RequestBody { get; set; }

        public string GetQueryString()
        {
            var dict = JsonSerializer.DeserializeFromString<Dictionary<string, string>>(RequestBody);

            dict.Add("version", "1");
            dict.Add("key", CoinpaymentsSettings.Default.PublicKey);

            return CryptoUtil.DictionaryToFormData(dict);
        }
    }
}
