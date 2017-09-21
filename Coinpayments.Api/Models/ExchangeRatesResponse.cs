using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    public class ExchangeRatesResponse : ResponseModelFoundation<Dictionary<string, ExchangeRatesResponse.Item>>
    {
        [DataContract]
        public class Item
        {
            [DataMember(Name = "is_fiat")]
            public string IsFiat { get; set; }
            [DataMember(Name = "rate_btc")]
            public decimal RateBtc { get; set; }
            [DataMember(Name = "last_update")]
            public int LastUpdate { get; set; }
            [DataMember(Name = "name")]
            public string Name { get; set; }
            [DataMember(Name = "confirms")]
            public int Confirms { get; set; }
        }
    }
}
