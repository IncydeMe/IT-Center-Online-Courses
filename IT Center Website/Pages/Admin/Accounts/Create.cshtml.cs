using App_BusinessObject.DTOs.Request.Account;
using App_Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages.Admin.Accounts
{
    public class CreateStaffAccountModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public CreateStaffAccountModel(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [BindProperty]
        public CreateAccountRequest CreateAccountRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _accountService.CreateAccount(CreateAccountRequest);

            return RedirectToPage("Index");
        }
    }
}
