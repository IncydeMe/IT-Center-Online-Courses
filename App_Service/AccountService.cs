using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_BusinessObject.DTOs.Request.Account;
using App_BusinessObject.DTOs.Response.Account;
using App_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_BusinessObject.DTOs.Request.Authentication;
using App_BusinessObject.DTOs.Response.Authentication;

namespace App_Service
{
    public interface IAccountService
    {
        public Task<IPaginate<GetAccountResponse>> GetAllAccounts(int page, int size);
        public void CreateAccount(CreateAccountRequest createAccountRequest);
        public Task<UpdateAccountResponse> UpdateAccountInformation(int id, UpdateAccountRequest updateAccountRequest);
        public Task<bool> ChangeAccountStatus(int id);

        public Task<LoginResponse> Login(LoginRequest loginRequest);
        public Task<LoginResponse> SignUp(SignUpRequest signUpRequest);
    }

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository = null;

        public AccountService()
        {
            if (_accountRepository == null)
                _accountRepository = new AccountRepository();
        }

        public async Task<IPaginate<GetAccountResponse>> GetAllAccounts(int page, int size) => await _accountRepository.GetAllAccounts(page, size);
        public async void CreateAccount(CreateAccountRequest createAccountRequest) => _accountRepository.CreateAccount(createAccountRequest);
        public async Task<UpdateAccountResponse> UpdateAccountInformation(int id, UpdateAccountRequest updateAccountRequest)
            => await _accountRepository.UpdateAccountInformation(id, updateAccountRequest);
        public async Task<bool> ChangeAccountStatus(int id) => await _accountRepository.ChangeAccountStatus(id);

        public async Task<LoginResponse> Login(LoginRequest loginRequest) => await _accountRepository.Login(loginRequest);
        public async Task<LoginResponse> SignUp(SignUpRequest signUpRequest) => await _accountRepository.SignUp(signUpRequest);
    }
}
