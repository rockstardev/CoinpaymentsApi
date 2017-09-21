using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    // https://www.coinpayments.net/apidoc-rates
    [DataContract]
    public class ExchangeRatesRequest
    {
        public ExchangeRatesRequest()
        {
            Cmd = "rates";
        }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }
        [DataMember(Name = "short")]
        public int Short { get; set; }
        [DataMember(Name = "accepted")]
        public int Accepted { get; set; }

    }
}
