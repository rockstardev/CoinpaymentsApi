using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    // https://www.coinpayments.net/apidoc-convert
    [DataContract]
    public class ConvertCoinsRequest
    {
        public ConvertCoinsRequest()
        {
            Cmd = "convert";
        }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }
        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }
        [DataMember(Name = "from")]
        public string Currency { get; set; }
        [DataMember(Name = "to")]
        public string Currency2 { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
        [DataMember(Name = "dest_tag")]
        public string DestTag { get; set; }
    }
}
