﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Application.Features.Accounts.Command
{
    public class AccountDeleteCommand :IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
