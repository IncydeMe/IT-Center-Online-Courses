using App_Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private IAccountRepository _accountRepository;
        public LoginModel(ILogger<LoginModel> logger,IAccountRepository accountRepository)
        {
            _logger = logger;
            this._accountRepository = accountRepository;
        }


        public void OnGet()
        {
        }

        [BindProperty]
        public string username { get; set; }
        [BindProperty]
        public string password { get; set; }

        public void OnPost()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            //Login logic + set token
            //HttpContext.Session.SetInt32("RoleId",1)
        }
    }
}
