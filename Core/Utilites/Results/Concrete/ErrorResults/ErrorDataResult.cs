using System.Net;

namespace Core.Utilites.Results.Concrete.ErrorResults
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, IEnumerable<string> messages, HttpStatusCode statusCode) : base(data, false, messages, statusCode)
        {
        }
        public ErrorDataResult(T data, string message, HttpStatusCode statusCode) : base(data, false, message, statusCode)
        {
        }
        public ErrorDataResult(T data, HttpStatusCode statusCode) : base(data, false, statusCode)
        {
        }

        public ErrorDataResult(IEnumerable<string> messages, HttpStatusCode statusCode) : base(default, false, messages, statusCode)
        {
        }
        public ErrorDataResult(string message, HttpStatusCode statusCode) : base(default, false, message, statusCode)
        {
        }
        public ErrorDataResult(HttpStatusCode statusCode) : base(default, false, statusCode)
        {
        }
    }
}
