using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses;
public class ExpenseValidator : AbstractValidator<RequestExpenseJson>
{
    public ExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourceErrorMessage.TITLE_IS_REQUIRED_ERROR);
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourceErrorMessage.AMOUNT_MUST_GREATER_THAN_ZERO_ERROR);
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessage.EXPENSE_CANNOT_FOR_THE_FUTURE_ERROR);
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessage.PAYMENT_TYPE_INVALID_ERROR);
        RuleFor(expense => expense.Tags).ForEach(rule =>
        {
            rule.IsInEnum().WithMessage(ResourceErrorMessage.TAG_TYPE_NOT_SUPPORTED_ERROR);
        });
    }
}
