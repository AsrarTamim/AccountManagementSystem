using AccountManagemnetSystem.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Application.Features.Accounts.Command
{
    public class AccountUpdateCommandHandler : IRequestHandler<AccountUpdateCommand, Guid>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        private readonly IMapper _mapper;

        public AccountUpdateCommandHandler(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AccountUpdateCommand command, CancellationToken cancellationToken)
        {
            var Account = await _applicationUnitOfWork.AccountRepository.GetByIdAsync(command.Id);

            if (Account == null)
                throw new Exception("Account not found");

            _mapper.Map(command, Account);

            _applicationUnitOfWork.AccountRepository.Update(Account);
            await _applicationUnitOfWork.SaveAsync();

            return Account.Id;
        }

    }
}
