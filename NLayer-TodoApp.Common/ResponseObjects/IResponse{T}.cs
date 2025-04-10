namespace NLayer_TodoApp.Common.ResponseObjects;

public interface IResponse<T> : IResponse
{
    T Data { get; }
    List<ResponseValidateErrors> Errors { get; }
}