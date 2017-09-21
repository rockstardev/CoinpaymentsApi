using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    public abstract class ResponseModel
    {
        public HttpUrlResponse HttpResponse { get; set; }

        public void ProcessJson()
        {
            if (HttpResponse.IsSuccessStatusCode)
            {
                var obj = JsonSerializer.DeserializeFromString(HttpResponse.ContentBody, this.GetType());
                this.PopulateWithNonDefaultValues(obj);
            }
        }
    }
}
