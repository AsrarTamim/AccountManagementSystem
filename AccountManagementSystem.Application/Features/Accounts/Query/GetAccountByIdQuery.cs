using AccountManagementSystem.Application.Features.Accounts.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Application.Features.Accounts.Query
{
    public class GetAccountByIdQuery : IRequest<AccountUpdateCommand>
    {
        public Guid Id { get; set; }
    }
}
