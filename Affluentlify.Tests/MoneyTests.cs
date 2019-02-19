using NUnit.Framework;
using Affluentlify;

namespace Affluentlify.Tests
{
    [TestFixture]
    public class MoneyTests
    {
        [TestCase(55, "GBP")]
        [TestCase(134.99, "USD")]
        [TestCase(21.876, "EUR")]
        [TestCase(19.444, "GBP")]
        public void NewMoney_CreatesNewMoneyObject(decimal amount, string currencyCode)
        {
            // Arrange
            var expectedAmount = decimal.Round(amount, 2, System.MidpointRounding.AwayFromZero);

            // Act
            var actual = new Money(amount, currencyCode);

            // Assert
            Assert.AreEqual(expectedAmount, actual.Amount);
            Assert.AreEqual(currencyCode, actual.CurrencyCode);
        }

        [TestCase(55, "GBP", 2)]
        [TestCase(134.99, "USD", 2)]
        [TestCase(21.876, "EUR", 2)]
        [TestCase(19.444, "GBP", 3)]
        [TestCase(67.9909, "EUR", 4)]
        public void NewMoney_WithDecimalPlaces_CreatesNewMoneyObject(decimal amount, string currencyCode, int decimalPlaces)
        {
            // Arrange
            var expectedAmount = decimal.Round(amount, decimalPlaces, System.MidpointRounding.AwayFromZero);

            // Act
            var actual = new Money(amount, currencyCode, decimalPlaces);

            // Assert
            Assert.AreEqual(expectedAmount, actual.Amount);
            Assert.AreEqual(currencyCode, actual.CurrencyCode);
        }

        public void ToDecimalPlaces_ReturnsMoneyObject_WithCorrectDecimalPlaces()
        {
            
        }
    }
}
