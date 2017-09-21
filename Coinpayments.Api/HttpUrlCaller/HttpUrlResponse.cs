using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api
{
    public class HttpUrlResponse
    {
        public HttpUrlResponse(
            HttpStatusCode statusCode,
            bool isSuccess,
            IEnumerable<KeyValuePair<string, IEnumerable<string>>> headers,
            string contentBody,
            string requestUri,
            string requestbody)
        {
            this.Headers = headers.ToList();
            this.StatusCode = statusCode;
            this.ContentBody = contentBody;
            this.IsSuccessStatusCode = isSuccess;

            RequestUri = requestUri;
            RequestBody = requestbody;
        }

        public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers { get; private set; }
        public string ContentBody { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public bool IsSuccessStatusCode { get; private set; }

        public string RequestUri { get; private set; }
        public string RequestBody { get; private set; }
    }
}
