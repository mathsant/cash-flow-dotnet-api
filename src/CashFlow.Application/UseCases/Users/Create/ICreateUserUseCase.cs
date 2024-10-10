using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Users.Create;
public interface ICreateUserUseCase
{
    Task<ResponseCreatedUserJson> Execute(RequestCreateUserJson request);
}
