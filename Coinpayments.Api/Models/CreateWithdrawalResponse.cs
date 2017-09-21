using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    public class CreateWithdrawalResponse : ResponseModelFoundation<CreateWithdrawalResponse.Item>
    {
        [DataContract]
        public class Item
        {
            [DataMember(Name = "id")]
            public string Id { get; set;} 
            [DataMember(Name = "status")]
            public int Status { get; set; }
            [DataMember(Name = "amount")]
            public decimal Amount { get; set; }
        }
    }
}
