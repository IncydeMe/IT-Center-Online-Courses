using App_BusinessObject.DTOs.Request.Authentication;
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

        [BindProperty]
        public LoginRequest LoginRequest { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var account = await _accountRepository.Login(LoginRequest);

            if(account != null)
            {
                //Not use filter
                switch(account.Role)
                {
                    case "Administrator":
                        HttpContext.Session.SetString("Role", "Administrator");
                        return RedirectToPage("/Admin/Index");
                    case "Staff":
                        HttpContext.Session.SetString("Role", "Staff");
                        return RedirectToPage("/Staff/Index");
                    case "Learner":
                        HttpContext.Session.SetString("Role", "Learner");
                        return RedirectToPage("/Learner/Index");
                }
            }

            ErrorMessage = "Incorrect email or password";
            return Page();
        }
    }
}
