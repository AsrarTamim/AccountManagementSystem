﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AccountManagementSystem.Infrastructure.Identity
{
    public class ApplicationUserRole
        : IdentityUserRole<Guid>
    {
       
    }
}
