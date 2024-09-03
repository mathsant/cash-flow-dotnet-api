using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestExpenseJson request)
    {
        try
        {
            var response = new RegisterExpenseUseCase().Execute(request);

            return Created(string.Empty, response);
        }
        catch (ArgumentException ex)
        {
            var errorResponse = new ResponseErrorJson
            {
                ErrorMessage = ex.Message
            };

            return BadRequest(errorResponse);
        }
        catch
        {
            var errorResponse = new ResponseErrorJson
            {
                ErrorMessage = "Unknown error."
            };

            return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}
