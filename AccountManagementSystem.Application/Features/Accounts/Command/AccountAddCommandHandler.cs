using AccountManagementSystem.Domain;
using AccountManagementSystem.Domain.Entities;
using AccountManagemnetSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Application.Features.Accounts.Command
{
    public class AccountAddCommandHandler : IRequestHandler<AccountAddCommand>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public AccountAddCommandHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }
        public async Task Handle(AccountAddCommand request, CancellationToken cancellationToken)
        {
           
            await _applicationUnitOfWork.AccountRepository.AddAsync(new Account
            {
                Id = IdentityGenerator.NewSequentialGuid(),
                Name = request.Name,
                AccountType = request.AccountType,
                Cash = request.Cash
            });

            await _applicationUnitOfWork.SaveAsync();
        }
    }
}
