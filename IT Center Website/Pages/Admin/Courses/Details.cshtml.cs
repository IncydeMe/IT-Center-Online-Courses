using App_BusinessObject.DTOs.Response.Course;
using App_Repository.Interfaces;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages.Admin.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ICourseRepository _courseRepository;

        public DetailsModel(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [BindProperty]
        public GetCourseResponse Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (_courseRepository.GetCourseById(id).Result == null)
            {
                return NotFound();
            }
            Course = _courseRepository.GetCourseById(id).Result;
            return Page();
        }
    }
}
