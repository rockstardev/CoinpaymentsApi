using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    // https://www.coinpayments.net/apidoc-create-withdrawal
    [DataContract]
    public class CreateWithdrawalRequest
    {
        public CreateWithdrawalRequest()
        {
            Cmd = "create_withdrawal";
        }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }
        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }
        [DataMember(Name = "currency")]
        public string Currency { get; set; }
        [DataMember(Name = "currency2")]
        public string Currency2 { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
        [DataMember(Name = "pbntag")]
        public string Pbntag { get; set; }
        [DataMember(Name = "dest_tag")]
        public string DestTag { get; set; }
        [DataMember(Name = "ipn_url")]
        public string IpnUrl { get; set; }
        [DataMember(Name = "auto_confirm")]
        public string AutoConfirm { get; set; }
        [DataMember(Name = "note")]
        public string Note { get; set; }

    }
}
