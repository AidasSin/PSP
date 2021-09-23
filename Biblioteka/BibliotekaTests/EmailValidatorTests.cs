using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteka.Tests
{
    [TestClass]
    public class EmailValidatorTests
    {
        readonly EmailValidator emailValidator = new EmailValidator();
        [TestMethod]
        public void Email_WhenEmpty_ShouldReturnFalse()
        {
            var isEmailValid = emailValidator.IsEmailValid("");
            Assert.AreEqual(false, isEmailValid, "The email address is not valid because it is empty");
        }
        [TestMethod]
        public void Email_WhenNull_ShouldReturnFalse()
        {
            var isEmailValid = emailValidator.IsEmailValid(null);
            Assert.AreEqual(false, isEmailValid, "The email address is not valid because the value provided is null.");
        }
        [TestMethod]
        public void Email_WhenWithoutAlphaSymbol_ShouldReturnFalse()
        {
            var isEmailValid = emailValidator.IsEmailValid("pastas&bealpha.lt");
            Assert.AreEqual(false, isEmailValid, "The email address is not valid because it doesn't have the @ symbol.");
        }
        [TestMethod]
        public void Email_WhenWithBlockedSymbols_ShouldReturnFalse()
        {
            var isEmailValid = emailValidator.IsEmailValid("pa;st,as@pastas.lt");
            Assert.AreEqual(false, isEmailValid, "The email address is not valid because it has blocked symbols.");
        }
        [TestMethod]
        public void Email_WhenWithEmptyBeginning_ShouldReturnFalse()
        {
            var isEmailValid = emailValidator.IsEmailValid("@gmail.com");
            Assert.AreEqual(false, isEmailValid, "The email address is not valid because the first part is empty.");
        }
        [TestMethod]
        public void Email_WhenWithEmptyEnd_ShouldReturnFalse()
        {
            var isEmailValid = emailValidator.IsEmailValid("pastas@.com");
            Assert.AreEqual(false, isEmailValid, "The email address is not valid because the second part is empty.");
        }
        [TestMethod]
        public void Email_WhenWithIncorrectDomain_ShouldReturnFalse()
        {
            var isEmailValid = emailValidator.IsEmailValid("pastas@neteisingasdomenas.klaida");
            Assert.AreEqual(false, isEmailValid, "The email address is not valid because the domain doesn't exist");
        }
    }
}