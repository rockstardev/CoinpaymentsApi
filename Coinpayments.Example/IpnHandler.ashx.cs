using Coinpayments.Api.Ipns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Coinpayments.Example
{
    /// <summary>
    /// IPN Handler for Coinpayments, see https://www.coinpayments.net/merchant-tools-ipn
    /// </summary>
    public class IpnHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var req = IpnBase.Parse<IpnApi>(context.Request.Form);

            var hmac = context.Request.Headers["HMAC"];
            if (hmac == null || !req.SigIsValid(hmac))
            {
                response(context, HttpStatusCode.BadRequest, "Invalid HMAC / MerchantId");
                return;
            }
            
            if (checkForDuplicate(req))
            {
                response(context, HttpStatusCode.OK, "Duplicate transactions");
                return;
            }

            if (req.SuccessStatusLax() && req.IpnType == "api")
            {
                // TODO: Process payment as needed, release product
            }

            response(context, HttpStatusCode.OK, "1");
        }

        private bool checkForDuplicate(IpnApi req)
        {
            // TODO: Implement check against database if needed
            return false;
        }

        private void response(HttpContext context, HttpStatusCode statusCode, string text)
        {
            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "text/plain";
            context.Response.Write(text);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}