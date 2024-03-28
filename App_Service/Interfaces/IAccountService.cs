using App_BusinessObject.DTOs.Request.Account;
using App_BusinessObject.DTOs.Request.Authentication;
using App_BusinessObject.DTOs.Response.Account;
using App_BusinessObject.DTOs.Response.Authentication;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface IAccountService
    {
        public Task<IPaginate<GetAccountResponse>> GetAllAccounts(int page, int size);
        public Task CreateAccount(CreateAccountRequest createAccountRequest);
        public Task<UpdateAccountResponse> UpdateAccountInformation(int id, UpdateAccountRequest updateAccountRequest);
        public Task<bool> ChangeAccountStatus(int id);
        public Task<Account> GetAccountById(int accountId);
        public Task<bool> ChangeRole(int accountId, int roleId);

        public Task<LoginResponse> Login(LoginRequest loginRequest);
        public Task<LoginResponse> SignUp(SignUpRequest signUpRequest);
    }
}
