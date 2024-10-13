using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users.Create;
public class CreateUserValidator : AbstractValidator<RequestCreateUserJson>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage("NAME_EMPTY");
        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("EMAIL_EMPTY")
            .EmailAddress()
            .When(user => string.IsNullOrWhiteSpace(user.Email) == false, ApplyConditionTo.CurrentValidator)
            .WithMessage("EMAIL_INVALID");
        RuleFor(user => user.Password).SetValidator(new PasswordValidator<RequestCreateUserJson>());
    }
}
