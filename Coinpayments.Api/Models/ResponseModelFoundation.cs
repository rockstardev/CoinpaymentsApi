using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    [DataContract]
    public class ResponseModelFoundation<T> : ResponseModel
    {
        public string Error { get; set; }
        public T Result { get; set; }

        public bool IsSuccess { get { return Error == "ok"; } }
    }
}
