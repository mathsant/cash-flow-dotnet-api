using Bogus;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestCreateUserJsonBuilder
{
    public static RequestCreateUserJson Build()
    {
        return new Faker<RequestCreateUserJson>()
            .RuleFor(user => user.Name, faker => faker.Person.FirstName)
            .RuleFor(user => user.Email, (faker, user) => faker.Internet.Email(user.Name))
            .RuleFor(user => user.Password, faker => faker.Internet.Password(prefix: "!Aa1"));
    }
}
