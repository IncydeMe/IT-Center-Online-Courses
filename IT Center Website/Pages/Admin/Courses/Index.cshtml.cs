using App_BusinessObject.DTOs.Response.Account;
using App_BusinessObject.DTOs.Response.Course;
using App_BusinessObject.Models;
using App_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace IT_Center_Website.Pages.Admin.Courses
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly ICourseService _courseService;
		private int size = 10;

		public IndexModel(ILogger<IndexModel> logger, ICourseService courseService)
		{
			_logger = logger;
			_courseService = courseService;
		}

		[BindProperty]
		public List<GetCourseResponse> Courses { get; set; }

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
			TotalPages = courses.TotalPages;
			this.PageNumber = courses.Page;

			if (courses != null)
			{
				Courses = (List<GetCourseResponse>)courses.Items;
			}
		}
	}
}
