﻿using System.Runtime.InteropServices.ComTypes;

namespace Core.Utilites.Results.Abstract
{
   public interface IDataResult<T>:IResult
    {
        T Data { get; } 
    }
}
