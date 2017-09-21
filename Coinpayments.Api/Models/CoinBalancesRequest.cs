using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    // https://www.coinpayments.net/apidoc-balances
    [DataContract]
    public class CoinBalancesRequest
    {
        public CoinBalancesRequest()
        {
            Cmd = "balances";
        }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }
        [DataMember(Name = "all")]
        public int All { get; set; }

    }
}
