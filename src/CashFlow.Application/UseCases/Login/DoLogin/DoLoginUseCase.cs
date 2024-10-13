using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryp;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Login.DoLogin;
public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly IPasswordCryp _passwordCryp;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public DoLoginUseCase(IUserReadOnlyRepository repository, IPasswordCryp passwordCryp, IAccessTokenGenerator accessTokenGenerator)
    {
        _accessTokenGenerator = accessTokenGenerator;
        _repository = repository;
        _passwordCryp = passwordCryp;
    }

    public async Task<ResponseCreatedUserJson> Execute(RequestLoginJson request)
    {
        var user = await _repository.GetUserByEmail(request.Email);

        if (user is null) throw new InvalidLoginException();

        var passwordMatch = _passwordCryp.Verify(request.Password, user.Password);

        if (passwordMatch == false) throw new InvalidLoginException();

        return new ResponseCreatedUserJson
        {
            Name = user.Name,
            Token = _accessTokenGenerator.Generate(user)
        };
    }
}
