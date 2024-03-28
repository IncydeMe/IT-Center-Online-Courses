using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App_BusinessObject.Models;
using App_Service.Interfaces;

namespace IT_Center_Website.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ICourseService _courseService;

        public DetailsModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

      public Course Course { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _courseService.GetAllACourses == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            else 
            {
                Course = course;
            }
            return Page();
        }
    }
}
