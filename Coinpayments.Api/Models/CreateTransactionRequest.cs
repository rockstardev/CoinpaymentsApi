using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    // https://www.coinpayments.net/apidoc-create-transaction
    [DataContract]
    public class CreateTransactionRequest
    {
        public CreateTransactionRequest()
        {
            Cmd = "create_transaction";
        }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }
        [DataMember(Name = "amount")]
        public decimal Amount { get; set; }
        [DataMember(Name = "currency1")]
        public string Currency1 { get; set; }
        [DataMember(Name = "currency2")]
        public string Currency2 { get; set; }
        [DataMember(Name = "address")]
        public string Address { get; set; }
        [DataMember(Name = "buyer_email")]
        public string BuyerEmail { get; set; }
        [DataMember(Name = "buyer_name")]
        public string BuyerName { get; set; }
        [DataMember(Name = "item_name")]
        public string ItemName { get; set; }
        [DataMember(Name = "item_number")]
        public string ItemNumber { get; set; }
        [DataMember(Name = "invoice")]
        public string Invoice { get; set; }
        [DataMember(Name = "custom")]
        public string Custom { get; set; }
        [DataMember(Name = "ipn_url")]
        public string IpnUrl { get; set; }

    }
}
