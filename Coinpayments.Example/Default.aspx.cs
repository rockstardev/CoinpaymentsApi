using Coinpayments.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coinpayments.Example
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnBuy_Click(object sender, EventArgs e)
        {
            var purchase = await CoinpaymentsApi.CreateTransaction(10, "USD", "LTCT", "peusa@outlook.com");
            Response.Redirect(purchase.Result.StatusUrl);
        }
    }
}