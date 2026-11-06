namespace BombonesApp2026.Servicios.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public T? Value { get; private set; }
        public List<string> Errors { get; } = new();
        private Result(bool success, List<string> errors, T? value = default)
        {
            IsSuccess = success;
            Errors = errors;
            Value = value;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(true, new List<string>(), value);
        }
        public static Result<T> Failure(List<string> errors)
        {
            return new Result<T>(false, errors);
        }
        public static Result<T> Failure(string error)
        {
            return new Result<T>(false, new List<string> { error });
        }
    }

}
