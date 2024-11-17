using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.LoggedUser;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using FluentAssertions;

namespace UseCases.Test.Expenses.GetById;
public class GetExpenseByIdUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var loggedUser = UserBuilder.Build();
        var expense = ExpenseBuilder.Build(loggedUser);

        var useCase = CreateUseCase(loggedUser, expense);

        var result = await useCase.Execute(expense.Id);

        result.Should().NotBeNull();
        result.Id.Should().Be(expense.Id);
        result.Title.Should().Be(expense.Title);
        result.Description.Should().Be(expense.Description);
        result.Date.Should().Be(expense.Date);
        result.Amount.Should().Be(expense.Amount);
        result.PaymentType.Should().Be((CashFlow.Communication.Enums.PaymentType)expense.PaymentType);
        result.Tags.Should().NotBeNullOrEmpty().And.BeEquivalentTo(expense.Tags.Select(tag => tag.Value));
    }

    private GetExpenseByIdUseCase CreateUseCase(User user, Expense? expense = null)
    {
        var repository = new ExpenseReadOnlyRepositoryBuilder().GetById(user, expense).Build();
        var mapper = MapperBuilder.Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new GetExpenseByIdUseCase(repository, mapper, loggedUser);
    }
}
