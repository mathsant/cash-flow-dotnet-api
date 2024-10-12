using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Login.DoLogin;
public interface IDoLoginUseCase
{
    Task<ResponseCreatedUserJson> Execute(RequestLoginJson request);
}
