using System.Net;

namespace Core.Utilites.Results.Concrete.ErrorResults
{
   public class ErrorResult:Result
    {
        public ErrorResult(IEnumerable<string> messages, HttpStatusCode statusCode) : base(false, messages, statusCode)
        {
        }
        public ErrorResult(string message, HttpStatusCode statusCode) : base(false, message, statusCode)
        {
        }
        public ErrorResult(HttpStatusCode statusCode) : base(false, statusCode)
        {
        }
    }
}
