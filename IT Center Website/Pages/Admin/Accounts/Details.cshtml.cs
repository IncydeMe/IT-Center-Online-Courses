using App_BusinessObject.Models;
using App_Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages.Admin.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public DetailsModel(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [BindProperty]
        public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (_accountService.GetAllAccounts(1, 999).Result.Items == null)
            {
                return NotFound();
            }
            Account = _mapper.Map<Account>(_accountService.GetAccountById(id).Result);
            return Page();
        }
    }
}
