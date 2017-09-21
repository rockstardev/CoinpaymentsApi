using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Coinpayments.Api.Models
{
    // https://www.coinpayments.net/apidoc-create-withdrawal
    [DataContract]
    public class CreateMassWithdrawalRequest
    {
        public CreateMassWithdrawalRequest()
        {
            Cmd = "create_mass_withdrawal";
        }

        [DataMember(Name = "cmd")]
        public string Cmd { get; private set; }

        private List<Item> Wd;

        public void AddWithdrawal(decimal amount, string address, string currency)
        {
            if (Wd == null)
                Wd = new List<Item>();

            Wd.Add(new Item { Amount = amount, Address = address, Currency = currency });
        }

        // TODO: Query call requires associate arrays, and doing those in HTTP Post Body is sad
        // especially when you are using FormData -> JSON -> FormData
        public string GetRequestBody()
        {
            var sb = new StringBuilder();
            sb.Append("{");
            sb.Append("\"cmd\":\"create_mass_withdrawal\"");

            for (int i = 0; i < Wd.Count; i++)
            {
                sb.Append(",");
                var item = Wd[i];
                sb.AppendFormat("\"wd[wd{0}][amount]\":{1},\"wd[wd{0}][address]\":\"{2}\",\"wd[wd{0}][currency]\":\"{3}\"",
                    i, item.Amount, item.Address, item.Currency);
            }
            sb.Append("}");

            return sb.ToString();
        }

        public class Item
        {
            [DataMember(Name = "amount")]
            public decimal Amount { get; set; }
            [DataMember(Name = "address")]
            public string Address { get; set; }
            [DataMember(Name = "currency")]
            public string Currency { get; set; }
        }
    }
}
