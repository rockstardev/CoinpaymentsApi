using Coinpayments.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Helpers
{
    public class ExchangeRateHelper
    {
        public ExchangeRateHelper(Dictionary<string, ExchangeRatesResponse.Item> result)
        {
            if (result == null)
                return;

            UsdBtc = result["USD"].RateBtc;
            BtcUsd = 1 / UsdBtc;

            var ltcBtc = result["LTC"].RateBtc;
            LtcUsd = ltcBtc / UsdBtc;
            UsdLtc = 1 / LtcUsd;

            var ethBtc = result["ETH"].RateBtc;
            EthUsd = ethBtc / UsdBtc;
            UsdEth = 1 / EthUsd;

            TestLtctUsd = 50;
            TestUsdLtct = 1 / TestLtctUsd;
        }

        public decimal BtcUsd { get; set; }
        public decimal UsdBtc { get; set; }

        public decimal LtcUsd { get; set; }
        public decimal UsdLtc { get; set; }

        public decimal EthUsd { get; set; }
        public decimal UsdEth { get; set; }

        public decimal TestLtctUsd { get; set; }
        public decimal TestUsdLtct { get; set; }
    }
}
