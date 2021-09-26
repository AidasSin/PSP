using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSPLibrary.Tests.Interfaces;

namespace PSPLibrary.Tests
{
	[TestClass]
	class PasswordValidatorTests
	{
		private IPasswordValidator _passwordValidator;

        public PasswordValidatorTests(IPasswordValidator passwordValidator)
        {
            _passwordValidator = passwordValidator;
        }

        [TestMethod]
		public void CheckPassword_ValidPassword_ReturnsTrue()
		{
			//Arrange
			string password = "ValidPassword123!";

			//Act
			var result = _passwordValidator.CheckPassword(password);

			//Assert
			Assert.AreEqual(true, result);
		}

		[TestMethod]
		public void CheckPassword_TooShort_ReturnsFalse()
		{
			//Arrange
			string password = "Val1";

			//Act
			var result = _passwordValidator.CheckPassword(password);

			//Assert
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void CheckPassword_HasNoUppercaseCharacters_ReturnsFalse()
		{
			//Arrange
			string password = "invalidpassword1";

			//Act
			var result = _passwordValidator.CheckPassword(password);

			//Assert
			Assert.AreEqual(false, result);
		}

		[TestMethod]
		public void CheckPassword_HasNoSpecialCharacter_ReturnsFalse()
		{
			//Arrange
			string password = "InvalidPassword";

			//Act
			var result = _passwordValidator.CheckPassword(password);

			//Assert
			Assert.AreEqual(false, result);
		}
	}
}
