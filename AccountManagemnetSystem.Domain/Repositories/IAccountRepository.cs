using AccountManagementSystem.Domain;
using AccountManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagemnetSystem.Domain.Repositories
{
    public interface IAccountRepository : IRepository<Account, Guid>
    {
        (IList<Account> data, int total, int totalDisplay) GetPagedAccount(int pageIndex,
            int pageSize, string? order, DataTablesSearch search);
    }
}
