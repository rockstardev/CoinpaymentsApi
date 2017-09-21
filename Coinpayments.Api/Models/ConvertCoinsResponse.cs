using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    public class ConvertCoinsResponse : ResponseModelFoundation<ConvertCoinsResponse.Item>
    {
        [DataContract]
        public class Item
        {
            [DataMember(Name = "id")]
            public string Id { get; set;} 
        }
    }
}
