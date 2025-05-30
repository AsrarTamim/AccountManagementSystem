using AccountManagemnetSystem.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountManagementSystem.Domain.Entities;

namespace AccountManagementSystem.Application.Features.Accounts.Query
{
    public class GetAccountQuery : IRequest<(IList<Account> data, int total, int totalDisplay)>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
        public AccountSearchDto Search { get; set; }
    }
}
