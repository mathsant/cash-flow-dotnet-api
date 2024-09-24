using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Expenses.Update;
public interface IUpdateExpenseUseCase
{
    Task<Expense> Execute(long id, RequestExpenseJson request);
}
