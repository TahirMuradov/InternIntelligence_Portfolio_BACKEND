﻿using Core.Utilites.Results.Abstract;

namespace Core.Helpers.EmailHelper.Abstract
{
   public interface IEmailHelper
    {
        public Task<IResult> SendEmailAsync(string userEmail, string confirmationLink, string UserName);
    }
}
