using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using App_BusinessObject.Models;
using App_Repository.Interfaces;
using App_Service.Interfaces;
using App_BusinessObject.Paginate;
using App_BusinessObject.DTOs.Response.Course;

namespace IT_Center_Website.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseService _courseService;

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IPaginate<GetCourseResponse> Course { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_courseService.GetAllCourses(1, 6) != null)
            {
                Course = await _courseService.GetAllCourses(1,6);
            }
        }
    }
}
