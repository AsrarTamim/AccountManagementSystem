using AccountManagementSystem.Application.Features.Accounts.Command;
using AccountManagementSystem.Domain.Entities;
using AccountManagementSystem.Web.Areas.Admin.Models.Account;
using AccountManagemnetSystem.Domain.Dtos;
using AutoMapper;

namespace AccountManagementSystem.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<AccountSearchModel, AccountSearchDto>().ReverseMap();
            CreateMap<AccountUpdateCommand, UpdateAccountModel>().ReverseMap();
            CreateMap<AccountUpdateCommand, UpdateAccountModel>().ReverseMap();
            CreateMap<Account, AccountUpdateCommand>().ReverseMap();

        }
    }
}
