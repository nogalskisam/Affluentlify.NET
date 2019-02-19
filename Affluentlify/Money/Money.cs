using System;
using System.Collections.Generic;
using System.Text;

namespace Affluentlify
{
    public class Money
    {
        /// <summary>
        /// The amount of money to 2 decimal places
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The ISO 4217 Currency Code of the Money object
        /// e.g. GBP for Great British Pounds or USD for United States Dollars
        /// </summary>
        public string CurrencyCode { get; set; }
    
        internal int DecimalPlaces { get; set; }

        internal decimal AccurateAmount { get; set; }

        /// <summary>
        /// Creates a new Money object. By default will round to 2 decimal places unless overload is specified or .ToDecimalPlaces(int decimalPlaces) is used
        /// </summary>
        /// <param name="amount">The Amount of money in the Money object</param>
        /// <param name="currencyCode">The currency code of the Money object, e.g. USD for United States Dollars</param>
        public Money(decimal amount, string currencyCode)
        {
            AccurateAmount = amount;
            Amount = decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
            CurrencyCode = currencyCode;
        }

        /// <summary>
        /// Creates a new Money object to the given number of decimal places.
        /// </summary>
        /// <param name="amount">The Amount of money in the Money object</param>
        /// <param name="currencyCode">The currency code of the Money object, e.g. USD for United States Dollars</param>
        /// <param name="decimalPlaces">The decimal places for the Amount property. Must be at least 2</param>
        public Money(decimal amount, string currencyCode, int decimalPlaces)
        {
            DecimalPlaces = decimalPlaces;

            if (decimalPlaces <= 1)
            {
                throw new Exception("Decimal places must be at least 2.");
            }

            AccurateAmount = amount;
            Amount = decimal.Round(amount, decimalPlaces, MidpointRounding.AwayFromZero);
            CurrencyCode = currencyCode;
        }
    }
}
