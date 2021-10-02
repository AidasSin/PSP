using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSPLibrary.Interfaces;
using PSPLibrary;

namespace PSPLibrary.Tests
{
	[TestClass]
	public class PasswordValidatorTests
	{
		readonly PasswordValidator _passwordValidator = new PasswordValidator();

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
