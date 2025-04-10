using NLayer_TodoApp.Common.ResponseObjects;
namespace NLayer_TodoApp.Common.ResponseObjects;

public interface IResponse
{
    string Message { get; }
    ResponseType ResponseType { get; }
}