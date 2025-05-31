using AccountManagementSystem.Domain;
using AccountManagementSystem.Domain.Entities;
using AccountManagemnetSystem.Domain.Repositories;
using AccountManagemnetSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Infrustructure.Repositories
{
    public class AccountRepository : Repository<Account, Guid>, IAccountRepository
    {
        private readonly AppDbContext _dbContext;
        public AccountRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool IsNameDuplicate(string name, Guid? id = null)
        {
            if (id.HasValue)
                return GetCount(x => x.Id != id.Value && x.Name == name) > 0;
            else
                return GetCount(x => x.Name == name) > 0;
        }

        (IList<Account> data, int total, int totalDisplay) IAccountRepository.GetPagedAccount(int pageIndex,
            int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrWhiteSpace(search.Value))
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            else
                return GetDynamic(x => x.Name.Contains(search.Value), order, null, pageIndex, pageSize, true);
        }

    }
}
