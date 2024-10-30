using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CashFlow.Infraestructure.DataAccess.Repositories;
internal class ExpensesRepository : IExpensesReadOnlyRepository, IExpensesWriteOnlyRepository, IExpensesUpdateOnlyRepository
{
    private CashFlowDbContext _dbContext;

    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }

    public async Task<List<Expense>> GetAll(User user)
    {
        return await _dbContext.Expenses.AsNoTracking().Where(expense => expense.UserId == user.Id).ToListAsync();
    }

    async Task<Expense?> IExpensesReadOnlyRepository.GetById(User user, long id)
    {
        return await GetFullExpense()
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == id && expense.UserId == user.Id);
    }

    async Task<Expense?> IExpensesUpdateOnlyRepository.GetById(User user, long id)
    {
        return await GetFullExpense()
            .FirstOrDefaultAsync(expense => expense.Id == id && expense.UserId == user.Id);
    }

    public async Task Delete(long id)
    {
        var result = await _dbContext.Expenses.FirstAsync(expense => expense.Id == id);

        _dbContext.Expenses.Remove(result);
    }

    public void Update(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }

    public async Task<List<Expense>> FilterByMonth(User user, DateOnly date)
    {
        var initialDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;

        var daysInMonth = DateTime.DaysInMonth(year: date.Year, month: date.Month);
        var endDate = new DateTime(year: date.Year, month: date.Month, day: daysInMonth, hour: 23, minute: 59, second: 59);

        var result = await _dbContext
            .Expenses
            .AsNoTracking()
            .Where(expense => expense.Date >= initialDate && expense.Date <= endDate && expense.UserId == user.Id)
            .OrderBy(expense => expense.Date)
            .ThenBy(expense => expense.Title)
            .ToListAsync();

        return result;
    }

    public async Task<List<Expense>> GetBtwDates(DateOnly initalDate, DateOnly endDate)
    {
        var initialDateFormatted = new DateTime(year: initalDate.Year, month: initalDate.Month, day: initalDate.Day).Date;
        var endDateFormatted = new DateTime(year: endDate.Year, month: endDate.Month, day: endDate.Day, hour: 23, minute: 59, second: 59);

        var result = await _dbContext
            .Expenses
            .AsNoTracking()
            .Where(expense => expense.Date >= initialDateFormatted && expense.Date <= endDateFormatted)
            .ToListAsync();

        return result;
    }

    private IIncludableQueryable<Expense, ICollection<Tag>> GetFullExpense()
    {
        return _dbContext.Expenses
            .Include(expense => expense.Tags);
    }
}
