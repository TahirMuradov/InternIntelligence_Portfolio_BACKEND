﻿using System.Net;

namespace Core.Utilites.Results.Abstract
{
    public interface IResult
    {
        public bool IsSuccess { get; }
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }
        public IEnumerable<string> Messages { get; }
    }
}
