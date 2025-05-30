using AccountManagementSystem.Domain.Entities;
using AccountManagemnetSystem.Domain.Dtos;
using AccountManagemnetSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagemnetSystem.Domain
{
    public interface IApplicationUnitOfWork : IUnitofWork
    {
        public  IAccountRepository _accountRepository { get; }
        Task<(IList<Account> data, int total, int totalDisplay)> GetAccounts(int pageIndex,
           int pageSize, string? order, AccountSearchDto search);
    }
}
