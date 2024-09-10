using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infraestructure.DataAccess;
public class CashFlowDbContext : DbContext
{
    public DbSet<Expense> expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=cash-flow-api;Uid=docker;Pwd=docker";

        var serverVersion = new MySqlServerVersion(new Version(8, 0));

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
