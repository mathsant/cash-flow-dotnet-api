namespace CashFlow.Communication.Responses;
public class ResponseErrorJson
{
    public List<string> ErrorMessages { get; set; }

    public ResponseErrorJson(string message)
    {
        ErrorMessages = [message];
    }

    public ResponseErrorJson(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
