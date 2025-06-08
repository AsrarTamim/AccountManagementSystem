﻿using Microsoft.AspNetCore.Identity;
using System;

namespace AccountManagementSystem.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
