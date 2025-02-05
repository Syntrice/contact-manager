namespace ContactManager.Wrappers;

public class ServiceObjectResponse<T> : ServiceResponse
{
    public T Value { get; }

    public ServiceObjectResponse(ServiceResponseType type, string? message, T value) : base(type, message)
    {
        Value = value;
    }

    public static ServiceObjectResponse<T> Success(string? message, T value) => 
        new ServiceObjectResponse<T>(ServiceResponseType.Success, message, value);
    public static ServiceObjectResponse<T> Failiure(string? message, T value) => 
        new ServiceObjectResponse<T>(ServiceResponseType.Failure, message, value);
    public static ServiceObjectResponse<T> Success(T value) =>
        Success(null, value);
    public static ServiceObjectResponse<T> Failiure(T value) =>
        Failiure(null, value);
}