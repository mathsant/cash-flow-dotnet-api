using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetByMonth;
public class GetExpensesByMonthUseCase : IGetExpensesByMonthUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;

    public GetExpensesByMonthUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Expense>> Execute(int year, int month)
    {
        var dateFormatted = new DateOnly(year: year, month: month, day: 1);

        var result = await _repository.FilterByMonth(dateFormatted);

        if (result.Count == 0) return [];

        return result;
    }
}
