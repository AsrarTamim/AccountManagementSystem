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



        }
    }
}
