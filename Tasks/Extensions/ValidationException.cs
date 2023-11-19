namespace Tasks.Extensions
{
    public class ValidationException : Exception
    {
        public ValidationException(string? message) : base(message)
        {
        }
    }
}
