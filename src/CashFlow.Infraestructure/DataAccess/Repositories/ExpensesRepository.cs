﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infraestructure.DataAccess.Repositories;
internal class ExpensesRepository : IExpensesRepository
{
    private CashFlowDbContext _dbContext;

    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Expense expense)
    {
        _dbContext.expenses.Add(expense);
    }
}
