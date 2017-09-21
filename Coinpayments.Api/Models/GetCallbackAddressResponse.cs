using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    public class GetCallbackAddressResponse : ResponseModelFoundation<GetCallbackAddressResponse.Item>
    {
        [DataContract]
        public class Item
        {
            public string Address { get; set; }
            public string PubKey { get; set; }
            public string Dest_Tag { get; set; }
        }
    }
}
