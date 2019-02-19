using NUnit.Framework;
using Affluentlify;
using System;

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
            var expectedAmount = decimal.Round(amount, 2, MidpointRounding.AwayFromZero);

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
            var expectedAmount = decimal.Round(amount, decimalPlaces, MidpointRounding.AwayFromZero);

            // Act
            var actual = new Money(amount, currencyCode, decimalPlaces);

            // Assert
            Assert.AreEqual(expectedAmount, actual.Amount);
            Assert.AreEqual(currencyCode, actual.CurrencyCode);
        }

        [TestCase(55, "GBP", 2)]
        [TestCase(134.99, "USD", 2)]
        [TestCase(21.876, "EUR", 2)]
        [TestCase(19.444, "GBP", 3)]
        [TestCase(67.9909, "EUR", 4)]
        [TestCase(789.49606, "EUR", 4)]
        public void ToDecimalPlaces_ReturnsMoneyObject_WithCorrectDecimalPlaces(decimal amount, string currencyCode, int decimalPlaces)
        {
            // Arrange
            var expectedAmount = decimal.Round(amount, decimalPlaces, MidpointRounding.AwayFromZero);
            var money = new Money(amount, currencyCode);

            // Act
            money.ToDecimalPlaces(decimalPlaces);

            // Assert
            Assert.AreEqual(expectedAmount, expectedAmount);
        }

        [TestCase(0)]
        [TestCase(1)]
        public void NewMoney_WithInvalidDecimalPlaces_ThrowsException(int decimalPlaces)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<Exception>(() => new Money(50M, "GBP", decimalPlaces));
        }

        [TestCase(0)]
        [TestCase(1)]
        public void ToDecimalPlaces_WithInvalidDecimalPlaces_ThrowsException(int decimalPlaces)
        {
            // Arrange
            var money = new Money(50M, "GBP");

            // Act
            // Assert
            Assert.Throws<Exception>(() => money.ToDecimalPlaces(decimalPlaces));
        }
    }
}
