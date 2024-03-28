using App_BusinessObject.DTOs.Request.Account;
using App_BusinessObject.DTOs.Response.Account;
using App_Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages.Admin.Accounts
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public EditModel(IAccountService accountService, IMapper mapper)
        {
			_accountService = accountService;
            _mapper = mapper;
		}

        [BindProperty]
        public UpdateAccountRequest UpdateAccountRequest { get; set; }
        public UpdateAccountResponse Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (_accountService.GetAccountById(id).Result == null)
            {
				return NotFound();
			}

            var account = await _accountService.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            Account = _mapper.Map<UpdateAccountResponse>(account);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
			if (!ModelState.IsValid)
            {
				return Page();
			}

			var updateAccount = await _accountService.UpdateAccountInformation(id, UpdateAccountRequest);
			if (updateAccount == null)
            {
				return NotFound();
			}

			return RedirectToPage("./Index");
		}
    }
}
