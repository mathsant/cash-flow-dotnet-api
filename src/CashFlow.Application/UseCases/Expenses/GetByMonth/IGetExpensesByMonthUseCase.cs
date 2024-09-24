using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Expenses.GetByMonth;
public interface IGetExpensesByMonthUseCase
{
    Task<List<Expense>> Execute(int year, int month);
}
