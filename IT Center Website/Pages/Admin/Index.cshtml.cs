using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
