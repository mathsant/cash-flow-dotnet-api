using CashFlow.Application.UseCases.Users.Create;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Users.Create;
public class CreateUserValidatorTest
{
    [Fact]
    public void Success()
    {
        var validator = new CreateUserValidator();
        var request = RequestCreateUserJsonBuilder.Build();

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Error_Name_Invalid(string name)
    {
        var validator = new CreateUserValidator();
        var request = RequestCreateUserJsonBuilder.Build();
        request.Name = name;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("NAME_EMPTY"));
    }

    [Theory]
    [InlineData("")]
    [InlineData("      ")]
    [InlineData(null)]
    public void Error_Email_Empty(string email)
    {
        var validator = new CreateUserValidator();
        var request = RequestCreateUserJsonBuilder.Build();
        request.Email = email;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("EMAIL_EMPTY"));
    }

    [Fact]
    public void Error_Email_Invalid()
    {
        var validator = new CreateUserValidator();
        var request = RequestCreateUserJsonBuilder.Build();
        request.Email = "matheus.com";

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals("EMAIL_INVALID"));
    }

    [Fact]
    public void Error_Password_Empty()
    {
        var validator = new CreateUserValidator();
        var request = RequestCreateUserJsonBuilder.Build();
        request.Password = string.Empty;

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessage.PASSWORD_INVALID));
    }
}
