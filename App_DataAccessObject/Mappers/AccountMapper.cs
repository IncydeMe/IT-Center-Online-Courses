using AutoMapper;
using App_BusinessObject.Models;
using App_BusinessObject.DTOs.Request.Account;
using App_BusinessObject.DTOs.Response.Account;

namespace App_DataAccessObject.Mappers
{
    public class AccountMapper : Profile
    {
        public AccountMapper()
        {
            CreateMap<CreateAccountRequest, Account>().ReverseMap();
            CreateMap<Account, UpdateAccountResponse>().ReverseMap();
            CreateMap<Account, GetAccountResponse>().ReverseMap();
        }
    }
}
