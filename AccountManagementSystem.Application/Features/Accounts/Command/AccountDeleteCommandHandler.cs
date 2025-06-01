using AccountManagemnetSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Application.Features.Accounts.Command
{
    public class AccountDeleteCommandHandler : IRequestHandler<AccountDeleteCommand, Guid>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        public AccountDeleteCommandHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }
        public Task<Guid> Handle(AccountDeleteCommand request, CancellationToken cancellationToken)
        {
            _applicationUnitOfWork.AccountRepository.Remove(request.Id);
            _applicationUnitOfWork.Save();
            return Task.FromResult(request.Id);
        }
    }
}
