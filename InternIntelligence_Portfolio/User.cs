﻿using Microsoft.AspNetCore.Identity;

namespace Entities
{
   public class User:IdentityUser<Guid>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiredDate { get; set; }
    }
}
