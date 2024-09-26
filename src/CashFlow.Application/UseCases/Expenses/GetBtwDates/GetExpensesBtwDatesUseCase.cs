using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetBtwDates;
public class GetExpensesBtwDatesUseCase : IGetExpensesBtwDatesUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;

    public GetExpensesBtwDatesUseCase(IExpensesReadOnlyRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Expense>> Execute(DateOnly initalDate, DateOnly endDate)
    {
        var result = await _repository.GetBtwDates(initalDate, endDate);

        if (result.Count == 0) return [];

        return result;
    }
}
