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
    public class CoinpaymentsApi
    {
        public static Task<GetCallbackAddressResponse> GetCallbackAddress(string currency)
        {
            var req = new HttpUrlRequest(new {
                cmd = "get_callback_address",
                currency 
            });

            return process<GetCallbackAddressResponse>(req);
        }

        public static Task<CreateTransactionResponse> CreateTransaction(
            decimal amount, string currency1, string currency2, string buyerEmail, 
            string custom = null, string itemNumber = null)
        {
            var req = new CreateTransactionRequest
            {
                Amount = amount,
                Currency1 = currency1,
                Currency2 = currency2,
                BuyerEmail = buyerEmail,
                Custom = custom,
                ItemNumber = itemNumber
            };

            return CreateTransaction(req);
        }


        public static Task<CreateTransactionResponse> CreateTransaction(CreateTransactionRequest request)
        {
            var req = new HttpUrlRequest(request);
            return process<CreateTransactionResponse>(req);
        }

        public static Task<CreateWithdrawalResponse> CreateWithdrawal(CreateWithdrawalRequest request)
        {
            var req = new HttpUrlRequest(request);
            return process<CreateWithdrawalResponse>(req);
        }

        public static Task<CreateMassWithdrawalResponse> CreateMassWithdrawal(CreateMassWithdrawalRequest request)
        {
            var req = new HttpUrlRequest(request);
            return process<CreateMassWithdrawalResponse>(req);
        }

        public static Task<ExchangeRatesResponse> ExchangeRates(bool isshort = false, bool accepted = false)
        {
            var request = new ExchangeRatesRequest
            {
                Short = isshort ? 1 : 0,
                Accepted = accepted ? 1 : 0
            };

            var req = new HttpUrlRequest(request);
            return process<ExchangeRatesResponse>(req);
        }

        public static Task<GetWithdrawalInfoResponse> GetWithdrawalInfo(string txnId)
        {
            var request = new GetWithdrawalInfoRequest { Id = txnId };
            var req = new HttpUrlRequest(request);
            return process<GetWithdrawalInfoResponse>(req);
        }

        public static Task<CoinBalancesResponse> CoinBalances(int all = 0)
        {
            var request = new CoinBalancesRequest
            {
                All = all
            };

            var req = new HttpUrlRequest(request);
            return process<CoinBalancesResponse>(req);
        }


        private static async Task<T1> process<T1>(HttpUrlRequest request)
            where T1 : ResponseModel, new()
        {
            var response = await HttpUrlCaller.GetResponse(request);

            var result = new T1();
            result.HttpResponse = response;
            result.ProcessJson();

            return result;
        }
    }
}
