﻿using Core.Utilites.Results.Abstract;
using System.Net;

namespace Core.Utilites.Results.Concrete
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }

        public IEnumerable<string> Messages { get; }
        public HttpStatusCode StatusCode { get; }
        public Result(bool IsSuccess, HttpStatusCode statusCode)
        {
            this.IsSuccess = IsSuccess;
            StatusCode = statusCode;
        }

        public Result(bool IsSuccess, string message, HttpStatusCode statusCode) : this(IsSuccess, statusCode)
        {
            Message = message;

        }
        public Result(bool IsSuccess, IEnumerable<string> messages, HttpStatusCode statusCode) : this(IsSuccess, statusCode)
        {
            Messages = messages;

        }
    }
}
