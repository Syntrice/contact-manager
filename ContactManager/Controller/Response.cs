namespace ContactManager.Logic
{
    public class Response<T>
    {
        public ResponseType Type { get; }   
        public string? Message { get; }
        public T Value { get; }

        public Response(ResponseType type, string? message, T value)
        {
            Type = type;
            Message = message;
            Value = value;
        }

        public static Response<T> Success(string? message, T value) => 
            new Response<T>(ResponseType.Success, message, value);
        public static Response<T> Failiure(string? message, T value) => 
            new Response<T>(ResponseType.Failiure, message, value);
        public static Response<T> Success(T value) =>
            Success(null, value);
        public static Response<T> Failiure(T value) =>
            Failiure(null, value);
    }

    public class Response
    {
        public string? Message { get; }
        public ResponseType Type { get; }

        public Response(ResponseType type, string? message)
        {
            Type = type; 
            Message = message;
        }

        public static Response Success(string? message) =>
            new Response(ResponseType.Success, message);
        public static Response Failiure(string? message) =>
            new Response(ResponseType.Failiure, message);
        public static Response Success() =>
            Success(null);
        public static Response Failiure() =>
            Failiure(null);
    }
}
