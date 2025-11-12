namespace FP_C.API.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public T Value { get; }
        public string Message { get; }

        private Result(bool isSuccess, T value, string message)
        {
            IsSuccess = isSuccess;
            Value = value;
            Message = message;
        }

        public static Result<T> Ok(T value, string msg = "") => new(true, value, string.IsNullOrEmpty(msg) ? "Operation successful" : msg);
        public static Result<T> Fail(string error) => new(false, default, error);
    }

    public class Result
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        private Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static Result Ok(string msg = "") => new(true, string.IsNullOrEmpty(msg) ? "Operation successful" : msg);
        public static Result Fail(string error) => new(false, error);
    }
}
