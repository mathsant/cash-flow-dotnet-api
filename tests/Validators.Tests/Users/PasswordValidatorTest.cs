using CashFlow.Application.UseCases.Users;
using CashFlow.Communication.Requests;
using FluentAssertions;
using FluentValidation;

namespace Validators.Tests.Users;
public class PasswordValidatorTest
{
    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    [InlineData("1234567")]
    [InlineData("aaaaaaaa")]
    [InlineData("AAAAAAAA")]
    [InlineData("Aaaaaaaa")]
    [InlineData("Aaaaaaa1")]
    public void Error_Password_Invalid(string password)
    {
        var validator = new PasswordValidator<RequestCreateUserJson>();

        var result = validator.IsValid(new ValidationContext<RequestCreateUserJson>(new RequestCreateUserJson()), password);

        result.Should().BeFalse();
    }
}
