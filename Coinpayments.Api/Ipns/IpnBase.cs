using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Ipns
{
    [DataContract]
    public abstract class IpnBase
    {
        [DataMember(Name = "ipn_version")]
        public string IpnVersion { get; set; }
        [DataMember(Name = "ipn_type")]
        public string IpnType { get; set; }
        [DataMember(Name = "ipn_mode")]
        public string IpnMode { get; set; }
        [DataMember(Name = "ipn_id")]
        public string IpnId { get; set; }
        [DataMember(Name = "merchant")]
        public string Merchant { get; set; }

        [IgnoreDataMember]
        public string Source { get; set; }

        public bool SigIsValid(string hmacSent)
        {
            var calcHmac = CryptoUtil.CalcSignature(Source, CoinpaymentsSettings.Default.IpnSecret);

            return hmacSent == calcHmac && Merchant == CoinpaymentsSettings.Default.MerchantId;
        }


        public static T Parse<T>(NameValueCollection form)
            where T : IpnBase
        {
            // auto_mapping to title case doesn't work easily
            // so we'll use json as intermediary
            var dict = new Dictionary<string, string>();
            foreach (var key in form.AllKeys)
                dict.Add(key, form[key]);

            var str = JsonSerializer.SerializeToString(dict);
            var req = JsonSerializer.DeserializeFromString<T>(str);

            //
            req.Source = CryptoUtil.DictionaryToFormData(dict);

            return req;
        }
    }
}
