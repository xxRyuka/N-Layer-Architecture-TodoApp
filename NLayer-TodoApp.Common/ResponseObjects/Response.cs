namespace NLayer_TodoApp.Common.ResponseObjects;

// Serviceden artik direk dtoda donmeyip respnseler doneceğiz
public class Response : IResponse
{
    public string Message { get; set; }
    public ResponseType ResponseType { get; set; }

    public static Response Success(string message)
    {
        return new Response { Message = message  , ResponseType = ResponseType.Success };   
    }

    public static Response Error(string message, ResponseType responseType = ResponseType.ValidateError)
    {
        return new Response { Message = message, ResponseType = responseType };
    }
}

    public enum ResponseType 
    {
        Success,
        ValidateError,
        NotFound,
    }
