﻿using CashFlow.Domain.Repositories;

namespace CashFlow.Infraestructure.DataAccess;
internal class UnitOfWork : IUnitOfWork
{
    private CashFlowDbContext _dbContext;

    public UnitOfWork(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
