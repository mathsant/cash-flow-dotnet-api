﻿using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;
public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> GetAll();
    Task<Expense?> GetById(long id);

    Task<List<Expense>> FilterByMonth(DateOnly date);

    Task<List<Expense>> GetBtwDates(DateOnly initalDate, DateOnly endDate);
}
