using CashFlow.Domain.Security.Cryp;
using CashFlow.Infraestructure.DataAccess;
using CommonTestUtilities.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Test;
public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private CashFlow.Domain.Entities.User _user;
    private string _password;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
            .ConfigureServices(services =>
            {
                var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<CashFlowDbContext>(config =>
                {
                    config.UseInMemoryDatabase("InMemoryDbForTesting");
                    config.UseInternalServiceProvider(provider);
                });

                var scope = services.BuildServiceProvider().CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<CashFlowDbContext>();
                var passwordCryp = scope.ServiceProvider.GetRequiredService<IPasswordCryp>();

                CreateInitialUserOnDatabase(dbContext, passwordCryp);
            });
    }

    public string GetEmailOfInitialUser() => _user.Email;
    public string GetNameOfInitialUser() => _user.Name;
    public string GetPasswordOfInitialUser() => _password;

    private void CreateInitialUserOnDatabase(CashFlowDbContext dbContext, IPasswordCryp passwordCryp)
    {
        _user = UserBuilder.Build();
        _password = _user.Password;

        _user.Password = passwordCryp.Encrypt(_user.Password);

        dbContext.Users.Add(_user);

        dbContext.SaveChanges();
    }
}
