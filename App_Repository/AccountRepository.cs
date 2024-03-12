﻿using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_BusinessObject.DTOs.Request.Account;
using App_BusinessObject.DTOs.Response.Account;
using App_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_BusinessObject.DTOs.Request.Authentication;
using App_BusinessObject.DTOs.Response.Authentication;

namespace App_Repository
{
    public interface IAccountRepository
    {
        public Task<IPaginate<GetAccountResponse>> GetAllAccounts(int page, int size);
        public void CreateAccount(CreateAccountRequest createAccountRequest);
        public Task<UpdateAccountResponse> UpdateAccountInformation(int id, UpdateAccountRequest updateAccountRequest);
        public Task<bool> ChangeAccountStatus(int id);

        public Task<LoginResponse> Login(LoginRequest loginRequest);
        public Task<LoginResponse> SignUp(SignUpRequest signUpRequest);
    }

    public class AccountRepository : IAccountRepository
    {
        public async Task<IPaginate<GetAccountResponse>> GetAllAccounts(int page, int size) => await AccountDAO.Instance.GetAllAccounts(page, size);
        public async void CreateAccount(CreateAccountRequest createAccountRequest) => AccountDAO.Instance.CreateAccount(createAccountRequest);
        public async Task<UpdateAccountResponse> UpdateAccountInformation(int id, UpdateAccountRequest updateAccountRequest) 
            => await AccountDAO.Instance.UpdateAccountInformation(id, updateAccountRequest);
        public async Task<bool> ChangeAccountStatus(int id) => await AccountDAO.Instance.ChangeAccountStatus(id);

        public async Task<LoginResponse> Login(LoginRequest loginRequest) => await AccountDAO.Instance.Login(loginRequest);
        public async Task<LoginResponse> SignUp(SignUpRequest signUpRequest) => await AccountDAO.Instance.SignUp(signUpRequest);
    }
}