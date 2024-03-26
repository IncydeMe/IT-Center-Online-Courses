using AutoMapper;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_BusinessObject.DTOs.Request.Account;
using App_BusinessObject.DTOs.Response.Account;
using App_DataAccessObject.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using App_BusinessObject.DTOs.Response.Authentication;
using App_BusinessObject.DTOs.Request.Authentication;

namespace App_DataAccessObject
{
    public class AccountDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper;

        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public AccountDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if(_mapper  == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new AccountMapper())).CreateMapper().ConfigurationProvider);
        }

        #region AccountFunction
        public async Task<IPaginate<GetAccountResponse>> GetAllAccounts(int page, int size)
        {
            IPaginate<GetAccountResponse> accountList = await _dbContext.Accounts.Select(x => new GetAccountResponse
            {
                AccountId = x.AccountId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                IsActive = x.IsActive,
                Role = x.Role.RoleName
            }).Where(x => x.IsActive == true).ToPaginateAsync(page, size, 1);
            return accountList;
        }

        public async Task CreateAccount(CreateAccountRequest createAccountRequest)
        {
            Account? account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Email.Equals(createAccountRequest.Email));

            if (account == null)
            {
                _dbContext.Accounts.Add(_mapper.Map<Account>(createAccountRequest));
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<UpdateAccountResponse> UpdateAccountInformation(int id, UpdateAccountRequest updateAccountRequest)
        {
            Account? account = await _dbContext.Accounts
                .FirstOrDefaultAsync(x => x.AccountId == id) 
                ?? throw new KeyNotFoundException($"No account found with ID {id}");

            account.FirstName = string.IsNullOrEmpty(updateAccountRequest.FirstName) ?
                                    account.FirstName : updateAccountRequest.FirstName;
                account.LastName = string.IsNullOrEmpty(updateAccountRequest.LastName) ?
                                    account.LastName : updateAccountRequest.LastName;
                account.Email = string.IsNullOrEmpty(updateAccountRequest.Email) ?
                                    account.Email : updateAccountRequest.Email;
                account.Address = string.IsNullOrEmpty(updateAccountRequest.Address) ?
                                    account.Address : updateAccountRequest.Address;
                account.Phone = string.IsNullOrEmpty(updateAccountRequest.Phone) ?
                                    account.Phone : updateAccountRequest.Phone;
                account.DigitalSignature = string.IsNullOrEmpty(updateAccountRequest.DigitalSignature) ?
                                    account.DigitalSignature : updateAccountRequest.DigitalSignature;
                account.BirthDate = updateAccountRequest.BirthDate;

                _dbContext.Accounts.Update(account);
                await _dbContext.SaveChangesAsync();

                UpdateAccountResponse response = _mapper.Map<UpdateAccountResponse>(account);
                return response;
        }

        public async Task<bool> ChangeAccountStatus(int id)
        {
            Account? account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == id);

            if (account != null)
            {
                account.IsActive = !account.IsActive;
                _dbContext.Accounts.Update(account);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        #endregion

        #region AuthenticationFunction
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            Account? account = await _dbContext.Accounts.Where(x => x.Email.Equals(loginRequest.Email) && 
                                                                   x.Password.Equals(loginRequest.Password))
                                                       .Include(p => p.Role).SingleOrDefaultAsync();

            if (account == null) return null;
            LoginResponse response = new LoginResponse(account.AccountId, account.Email, account.FirstName,
                                                       account.Role.RoleName, account.IsActive);

            var token = Utils.GenerateJwtToken(account);
            response.AccessToken = token;
            return response;
        }

        public async Task<LoginResponse> SignUp(SignUpRequest signUpRequest)
        {
            if (signUpRequest == null)
            {
                throw new ArgumentNullException(nameof(signUpRequest));
            }

            Account? account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Email.Equals(signUpRequest.Email));

            if (account != null) return null;
            Account newAccount = new Account()
            {
                AccountId = 0,
                RoleId = 3,
                FirstName = string.Empty,
                LastName = string.Empty,
                BirthDate = DateTime.Now,
                Email = signUpRequest.Email,
                Gender = true,
                Address = string.Empty,
                Phone = string.Empty,
                DigitalSignature = string.Empty,
                Password = signUpRequest.Password,
                IsActive = true,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
            };

            _dbContext.Accounts.Add(newAccount);
            await _dbContext.SaveChangesAsync();

            //Login
            Account? createdAccount = await _dbContext.Accounts.Where(x => x.Email.Equals(newAccount.Email) &&
                                                                   x.Password.Equals(newAccount.Password))
                                                       .Include(p => p.Role).SingleOrDefaultAsync();

            if (createdAccount == null)
            {
                throw new Exception("Account was not created.");
            }

            LoginResponse response = new LoginResponse(createdAccount.AccountId, createdAccount.Email, createdAccount.FirstName,
                                                       createdAccount.Role.RoleName, createdAccount.IsActive);

            var token = Utils.GenerateJwtToken(createdAccount);
            response.AccessToken = token;
            return response;
        }

        #endregion
    }
}
