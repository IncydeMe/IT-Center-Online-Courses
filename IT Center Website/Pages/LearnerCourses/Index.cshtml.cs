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
        private readonly int size = 3;

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public List<GetCourseResponse> Course { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync()
        {
            if (PageNumber == 0)
            {
                PageNumber = 1;
            }

            var courses = await _courseService.GetAllCourses(PageNumber, size);

            if (courses.Items != null)
            {
                Course = (List<GetCourseResponse>)courses.Items;
            }

        }

        public async Task OnPostAsync(int id)
        {

        }
    }
}
