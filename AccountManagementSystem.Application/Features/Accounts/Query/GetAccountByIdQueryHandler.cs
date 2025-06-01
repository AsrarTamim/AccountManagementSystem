using AccountManagementSystem.Application.Features.Accounts.Command;
using AccountManagemnetSystem.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Application.Features.Accounts.Query
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountUpdateCommand>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccountByIdQueryHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AccountUpdateCommand> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var Account = await _unitOfWork.AccountRepository.GetByIdAsync(request.Id);
            if (Account == null) throw new Exception("Account not found");

            return _mapper.Map<AccountUpdateCommand>(Account);
        }
    }
}
