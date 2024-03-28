using App_BusinessObject.DTOs.Request.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages
{
    public class SignupModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public SignUpRequest SignupRequest { get; set; }

        //public async Task<IActionResult> OnPostAsync()
        //{

        //}
    }
}
