using AccountManagementSystem.Domain.Entities;
using AccountManagemnetSystem.Domain;
using AccountManagemnetSystem.Domain.Dtos;
using AccountManagemnetSystem.Domain.Repositories;
using AccountManagemnetSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Infrustructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IAccountRepository AccountRepository { get; private set; }
        public ApplicationUnitOfWork(AppDbContext context, IAccountRepository accountRepository) : base(context)
        {
            AccountRepository = accountRepository;
        }
        public async Task<(IList<Account> data, int total, int totalDisplay)> GetAccountsp(int pageIndex,
           int pageSize, string order, AccountSearchDto search)
        {
            var procedureName = "GetAccounts";

            var result = await SqlUtility.QueryWithStoredProcedureAsync<Account>(procedureName,
                new Dictionary<string, object>
                {
                    { "PageIndex", pageIndex },
                    { "PageSize", pageSize },
                    { "OrderBy", order },
                    { "CashFrom", search.CashFrom },
                    { "CashTo" , search.CashTo },
                    { "Name", string.IsNullOrEmpty(search.Name) ? null : search.Name },
                    { "AccountType", string.IsNullOrEmpty(search.AccountType) ? null : search.AccountType }
                },
                new Dictionary<string, Type>
                {
                    { "Total", typeof(int) },
                    { "TotalDisplay", typeof(int) },
                });

            return (result.result, (int)result.outValues["Total"], (int)result.outValues["TotalDisplay"]);
        }
    }
}
