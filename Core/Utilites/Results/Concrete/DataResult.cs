using Core.Utilites.Results.Abstract;
using System.Net;

namespace Core.Utilites.Results.Concrete
{
   public class DataResult<T>:Result, IDataResult<T>
    {
        public T Data { get; }


        public DataResult(T data, bool Issuccess, IEnumerable<string> messages, HttpStatusCode statusCode) : base(Issuccess, messages, statusCode)
        {
            Data = data;
        }
    
        public DataResult(T data, bool Issuccess, string message, HttpStatusCode statusCode) : base(Issuccess, message, statusCode)
        {
            Data = data;
        }
        public DataResult(T data, bool success, HttpStatusCode statusCode) : base(success, statusCode)
        {
            Data = data;
        }
    }
}
