using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    public class CoinBalancesResponse : ResponseModelFoundation<Dictionary<string, CoinBalancesResponse.Item>>
    {
        [DataContract]
        public class Item
        {
            [DataMember(Name = "balance")]
            public long Balance { get; set;} 
            [DataMember(Name = "balancef")]
            public decimal BalanceFloat { get; set; }
            [DataMember(Name = "status")]
            public string Status { get; set; }
            [DataMember(Name = "coin_status")]
            public string CoinStatus { get; set; }
        }
    }
}
