using System.Net;

namespace Core.Utilites.Results.Concrete.SuccessResults
{
  public  class SuccessResult:Result
    {
        public SuccessResult(IEnumerable< string> messages, HttpStatusCode statusCode) : base(true, messages, statusCode)
        {
        }
        public SuccessResult(string message, HttpStatusCode statusCode) : base(true, message, statusCode)
        {
        }

        public SuccessResult(HttpStatusCode statusCode) : base(true, statusCode)
        {
        }
    }
}
