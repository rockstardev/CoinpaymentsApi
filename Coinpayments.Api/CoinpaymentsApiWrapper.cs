using Coinpayments.Api.Helpers;
using Coinpayments.Api.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api
{
    // extension of CoinpaymentsApi... addition of useful methods
    public class CoinpaymentsApiWrapper
    {
        public static async Task<ExchangeRateHelper> ExchangeRatesAsHelper()
        {
            var exchangeRates = await CoinpaymentsApi.ExchangeRates(accepted: true);
            if (!exchangeRates.IsSuccess)
                throw new Exception("Coinpayments error: " + exchangeRates.Error);

            var helper = new ExchangeRateHelper(exchangeRates.Result);
            return helper;
        }
    }
}
