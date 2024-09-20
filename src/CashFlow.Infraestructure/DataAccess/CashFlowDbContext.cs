using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infraestructure.DataAccess;
internal class CashFlowDbContext : DbContext
{

    public CashFlowDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Expense> expenses { get; set; }

}
