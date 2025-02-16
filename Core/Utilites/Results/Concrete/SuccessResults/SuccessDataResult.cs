using System.Net;

namespace Core.Utilites.Results.Concrete.SuccessResults
{
  public  class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,IEnumerable<string> messages, HttpStatusCode statusCode) : base(data, true,messages, statusCode)
        {
        }
        public SuccessDataResult(T data, string message, HttpStatusCode statusCode) : base(data, true, message, statusCode)
        {
        }
        public SuccessDataResult(T data, HttpStatusCode statusCode) : base(data, true, statusCode)
        {
        }

        public SuccessDataResult(string message, HttpStatusCode statusCode) : base(default, true, message, statusCode)
        {
        }
        public SuccessDataResult(IEnumerable<string> message, HttpStatusCode statusCode) : base(default, true, message, statusCode)
        {
        }
        public SuccessDataResult(HttpStatusCode statusCode) : base(default, true, statusCode)
        {
        }

    }
}
