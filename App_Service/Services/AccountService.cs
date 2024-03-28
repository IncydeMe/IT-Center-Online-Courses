using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_BusinessObject.DTOs.Request.Account;
using App_BusinessObject.DTOs.Response.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_BusinessObject.DTOs.Request.Authentication;
using App_BusinessObject.DTOs.Response.Authentication;
using App_Repository.Repositories;
using App_Service.Interfaces;
using App_Repository.Interfaces;

namespace App_Service.Services
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _accountRepository;

		public AccountService(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public async Task<IPaginate<GetAccountResponse>> GetAllAccounts(int page, int size) => await _accountRepository.GetAllAccounts(page, size);
		public async Task CreateAccount(CreateAccountRequest createAccountRequest) => _accountRepository.CreateAccount(createAccountRequest);
		public async Task<UpdateAccountResponse> UpdateAccountInformation(int id, UpdateAccountRequest updateAccountRequest)
			=> await _accountRepository.UpdateAccountInformation(id, updateAccountRequest);
		public async Task<bool> ChangeAccountStatus(int id) => await _accountRepository.ChangeAccountStatus(id);
		public async Task<Account> GetAccountById(int accountId) => await _accountRepository.GetAccountById(accountId);
		public async Task<bool> ChangeRole(int accountId, int roleId) => await _accountRepository.ChangeRole(accountId, roleId);

		public async Task<LoginResponse> Login(LoginRequest loginRequest) => await _accountRepository.Login(loginRequest);
		public async Task<LoginResponse> SignUp(SignUpRequest signUpRequest) => await _accountRepository.SignUp(signUpRequest);


	}
}
