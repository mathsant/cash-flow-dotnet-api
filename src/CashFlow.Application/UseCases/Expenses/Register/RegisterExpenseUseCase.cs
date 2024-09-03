using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestExpenseJson expense)
    {
        Validate(expense);

        return new ResponseRegisterExpenseJson();
    }

    private void Validate(RequestExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title.Trim());
        if (titleIsEmpty)
        {
            throw new ArgumentException("Title is required");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("The amount should be biggiest of zero");
        }

        var dateValidation = DateTime.Compare(request.Date, DateTime.UtcNow);
        if (dateValidation > 0)
        {
            throw new ArgumentException("Invalid date");
        }

        var paymentTypeIsValid = Enum.IsDefined(typeof(PaymentTypeEnum), request.PaymentType);
        if (paymentTypeIsValid == false)
        {
            throw new ArgumentException("Payment type is not valid");
        }
    }
}
