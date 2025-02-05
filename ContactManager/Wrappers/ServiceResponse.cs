using ContactManager.Wrappers;

namespace ContactManager.Wrappers
{
    public class ServiceResponse
    {
        public string? Message { get; }
        public ServiceResponseType Type { get; }

        public ServiceResponse(ServiceResponseType type, string? message)
        {
            Type = type; 
            Message = message;
        }

        public static ServiceResponse Success(string? message) =>
            new ServiceResponse(ServiceResponseType.Success, message);
        public static ServiceResponse Failiure(string? message) =>
            new ServiceResponse(ServiceResponseType.Failure, message);
        public static ServiceResponse Success() =>
            Success(null);
        public static ServiceResponse Failiure() =>
            Failiure(null);
    }
}
