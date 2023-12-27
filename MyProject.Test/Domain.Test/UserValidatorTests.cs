using FluentValidation.Results;
using MyProject.Domain.Entities;
using MyProject.Domain.Validators;
using Moq;
using Xunit;

namespace MyProject.Tests
{
    public class UserValidatorTests
    {
        [Theory]
        [InlineData("validemail@example.com", "ValidPassword123", "ValidPassword123", "JohnDoe", true, "+123456789")] // Valid user data
        [InlineData("", "Pass123", "Pass123", "JaneDoe", true, "+123456789")] // Empty email
        [InlineData("invalidemail", "Short", "Short", "User123", true, "+123")] // Invalid email and short passwords
        [InlineData("anotherinvalidemail", "ValidPwd123", "MismatchPwd123", "", true, "+abc")] // Mismatched passwords and empty username
        public void UserDataValidation_ShouldBeCorrect(
            string email,
            string password,
            string confirmPassword,
            string userName,
            bool isActive,
            string phoneNumber)
        {
            // Arrange
            var user = new Mock<User>();
            user.SetupAllProperties();
            user.Object.Email = email;
            user.Object.Password = password;
            user.Object.ConfirmPassword = confirmPassword;
            user.Object.UserName = userName;
            user.Object.IsActive = isActive;
            user.Object.PhoneNumber = phoneNumber;

            var validator = new UserValidator();

            // Act
            ValidationResult result = validator.Validate(user.Object);

            // Assert
            if (string.IsNullOrEmpty(email) || !email.Contains("@") || password.Length < 8 || password != confirmPassword ||
                string.IsNullOrEmpty(userName) || phoneNumber.Length < 3)
            {
                Assert.False(result.IsValid);
            }
            else
            {
                Assert.True(result.IsValid);
            }
        }
    }
}
