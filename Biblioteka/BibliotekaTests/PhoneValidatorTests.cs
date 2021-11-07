using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteka;
using System;
using System.Collections.Generic;
using System.Text;

/* Adding this comment here in order to shrink my initial PR and make it easier to see Tests. */

namespace Biblioteka.Tests
{
    [TestClass]
    public class PhoneValidatorTests
    {
        readonly PhoneValidator phoneValidator = new PhoneValidator();

        [TestMethod]
        public void PhoneNumber_WhenEmpty_ShouldReturnFalse()
        {
            var isPhoneNumberValid = phoneValidator.IsPhoneNumberValid("");
            Assert.AreEqual(false, isPhoneNumberValid, "The phone number isn't valid because the value is empty.");
        }
        [TestMethod]
        public void PhoneNumber_WhenNull_ShouldReturnFalse()
        {
            var isPhoneNumberValid = phoneValidator.IsPhoneNumberValid(null);
            Assert.AreEqual(false, isPhoneNumberValid, "The phone number isn't valid because the value is a null.");
        }
        [TestMethod]
        public void PhoneNumber_WithSymbolsOtherThanNumbers_ShouldReturnFalse()
        {
            var isPhoneNumberValid = phoneValidator.IsPhoneNumberValid("86AbcD224");
            Assert.AreEqual(false, isPhoneNumberValid, "The phone number isn't valid because it has other sybmbols than + or numbers.");
        }
        [TestMethod]
        public void PhoneNumber_WhenShorterThan12Symbols_ShouldReturnFalse()
        {
            var isPhoneNumberValid = phoneValidator.IsPhoneNumberValid("+3706123");
            Assert.AreEqual(false, isPhoneNumberValid, "The phone number isn't valid because it is shorter.");
        }
        [TestMethod]
        public void PhoneNumber_WhenBeginningWith8_ShouldChangeToLTUCode()
        {
            string number = "861234567";
            string changedNumber = "+37061234567";

            var numberToBeChanged = phoneValidator.ChangeNumberPrefix(number);

            Assert.AreEqual(numberToBeChanged, changedNumber);
        }
        [TestMethod]
        public void ValidationRule_ShouldBeCreated()
        {
            ValidationRule validationRule = new ValidationRule { length = 12, prefix = "+123" };

            var newRule = phoneValidator.AddValidationRule(12, "+123");

            Assert.AreEqual(validationRule.length, newRule.length);
            Assert.AreEqual(validationRule.prefix, newRule.prefix);
           
        }
    }
}