using App_BusinessObject.DTOs.Request.Authentication;
using App_BusinessObject.Models;
using App_Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;

namespace IT_Center_Website.Pages
{
    public class SignupModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private IAccountRepository _accountRepository;
        public SignupModel(ILogger<LoginModel> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            this._accountRepository = accountRepository;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public SignUpRequest SignupRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var signup = await _accountRepository.SignUp(SignupRequest);
            if (signup != null)
            {
                HttpContext.Session.SetString("Token", signup.AccessToken);

                switch (signup.Role)
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

            return Page();
        }
    }
}
