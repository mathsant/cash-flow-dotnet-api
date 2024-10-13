using CashFlow.Application.UseCases.Users.Create;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommonTestUtilities.Cryp;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using FluentAssertions;

namespace UseCases.Test.Users.Create;
public class CreateUserUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var request = RequestCreateUserJsonBuilder.Build();

        var useCase = CreateUseCase();  

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Name.Should().Be(request.Name);
        result.Token.Should().NotBeNull();
    }

    [Fact]
    public async Task Error_Name_Empty()
    {
        var request = RequestCreateUserJsonBuilder.Build();
        request.Name = string.Empty;

        var useCase = CreateUseCase();

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains("NAME_EMPTY"));
    }

    [Fact]
    public async Task Error_Email_Already_Exists()
    {
        var request = RequestCreateUserJsonBuilder.Build();

        var useCase = CreateUseCase(request.Email);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessage.EMAIL_ALREADY_EXISTS));
    }

    private CreateUserUseCase CreateUseCase(string? email = null)
    {
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var writeUserRepository = UserWriteOnlyRepositoryBuilder.Build();
        var passEncripter = new PasswordEncripterBuilder().Build();
        var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build();
        var readUserRepository = new UserReadOnlyRepositoryBuilder();

        if (string.IsNullOrWhiteSpace(email) == false)
        {
            readUserRepository.ExistActiveUserWithEmail(email);
        } 

        return new CreateUserUseCase(mapper, passEncripter, readUserRepository.Build(), writeUserRepository, unitOfWork, jwtTokenGenerator);
    }
}
