using System;
using System.Collections.Generic;
using System.Text;

namespace Affluentlify
{
    public static class MoneyExtensions
    {
        /// <summary>
        /// Set the number of decimal places for the money object
        /// </summary>
        /// <param name="decimalPlaces">The decimal places for the Amount property. Must be at least 2.</param>
        public static void ToDecimalPlaces(this Money money, int decimalPlaces)
        {
            money.DecimalPlaces = decimalPlaces;

            if (decimalPlaces <= 1)
            {
                throw new Exception("ToDecimalPlaces(int decimalPlaces) must be at least 2.");
            }
            else if (decimalPlaces == 2)
            {
                return;
            }
            else
            {
                money.Amount = decimal.Round(money.AccurateAmount, decimalPlaces, MidpointRounding.AwayFromZero);
            }
        }

        public static DbMoney ToDbMoney(this Money money)
        {
            return new DbMoney(money.Amount, money.CurrencyCode);
        }
    }
}
