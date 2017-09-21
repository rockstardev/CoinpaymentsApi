using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    // https://www.coinpayments.net/apidoc-get-withdrawal-info
    [DataContract]
    public class GetWithdrawalInfoRequest
    {
        public GetWithdrawalInfoRequest()
        {
            Cmd = "	get_withdrawal_info";
        }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
    }
}
