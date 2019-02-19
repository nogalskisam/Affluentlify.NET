using System;
using System.Collections.Generic;
using System.Text;

namespace Affluentlify
{
    public class DbMoney
    {
        public decimal Amount { get; set; }

        public string CurrencyCode { get; set; }

        public DbMoney(decimal amount, string currencyCode)
        {
            Amount = amount;
            CurrencyCode = currencyCode;
        }
    }
}
