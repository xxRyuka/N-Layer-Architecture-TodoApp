namespace NLayer_TodoApp.Common.ResponseObjects;

public class Response<T> : IResponse<T>
{
    public string Message { get; set; }
    public ResponseType ResponseType { get; set; }
    public T Data { get; set; }
    
    public List<ResponseValidateErrors> Errors { get; set; } = new List<ResponseValidateErrors>();

    public static Response<T> Success(T data, string message = null, ResponseType responseType = ResponseType.Success)
    {
        return new Response<T>()
        {
            Data = data,
            ResponseType = ResponseType.Success,
            Message = message
        };
    }

    public static Response<T> ValidateError(T data, string message, ResponseType responseType = ResponseType.ValidateError,List<ResponseValidateErrors> errors =null)
    {
        return new Response<T>()
        {
            Data = data,
            Message = message,
            ResponseType = ResponseType.ValidateError,
            Errors = errors
        };
    }

    public static Response<T> NotFound(string message, ResponseType responseType = ResponseType.NotFound)
    {
        return new Response<T>()
        {
            ResponseType = ResponseType.NotFound,
            Message = message
        };
    }
    
    
}