using App_BusinessObject.DTOs.Response.Account;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_Repository.Interfaces;
using App_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages.Admin.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAccountService _accountService;
        private int size = 10;

        public IndexModel(ILogger<IndexModel> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [BindProperty]
        public List<Account> Accounts { get; set; }
        public int? PageNumber { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int page)
        {
            if (PageNumber == null)
            {
                page = 1;
            }
            var pagesize = await _accountService.GetAllAccounts(page, size);
            TotalPages = pagesize.TotalPages;
            PageNumber = pagesize.Page;
            
            if (pagesize!= null)
            {
                Accounts = (List<Account>)pagesize.Items;
            }
        }
    }
}
