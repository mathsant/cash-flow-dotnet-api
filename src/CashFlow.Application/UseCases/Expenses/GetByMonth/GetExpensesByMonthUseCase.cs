using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;

namespace CashFlow.Application.UseCases.Expenses.GetByMonth;
public class GetExpensesByMonthUseCase : IGetExpensesByMonthUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private readonly ILoggedUser _loggedUser;

    public GetExpensesByMonthUseCase(IExpensesReadOnlyRepository repository, ILoggedUser loggedUser)
    {
        _repository = repository;
        _loggedUser = loggedUser;
    }

    public async Task<List<Expense>> Execute(int year, int month)
    {
        var loggedUser = await _loggedUser.Get();

        var dateFormatted = new DateOnly(year: year, month: month, day: 1);

        var result = await _repository.FilterByMonth(loggedUser, dateFormatted);

        if (result.Count == 0) return [];

        return result;
    }
}
