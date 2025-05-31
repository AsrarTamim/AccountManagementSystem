using AccountManagementSystem.Domain.Entities;
using AccountManagemnetSystem.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagementSystem.Application.Features.Accounts.Query
{
    public class GetAccountQueyHandler : IRequestHandler<GetAccountQuery, (IList<Account> data, int total, int totalDisplay)>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public GetAccountQueyHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(IList<Account> data, int total, int totalDisplay)> Handle(GetAccountQuery request,
            CancellationToken cancellationToken)
        {
            return await _unitOfWork.GetAccountsp(
                request.PageIndex,
                request.PageSize,
                request.OrderBy,
                request.Search
            );
        }
    }
}
