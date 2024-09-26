using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Expenses.GetBtwDates;
public interface IGetExpensesBtwDatesUseCase
{
    Task<List<Expense>> Execute(DateOnly initalDate, DateOnly endDate);
}
