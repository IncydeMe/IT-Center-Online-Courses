using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using App_BusinessObject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using App_Service.Interfaces;

namespace IT_Center_Website.Pages.Admin
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        // Assuming you have a service for courses and orders
        private readonly ICourseService _courseService;
        private readonly IOrderService _orderService;

        // Properties to hold the data for the charts
        public IList<Course> Courses { get; set; }
        public Dictionary<string, int> Orders { get; set; }
        public Dictionary<string, int> CourseCountsByCategory { get; set; }
        public int TotalOrders { get; set; }
        public int TotalCourses { get; set; }

        public IndexModel(ICourseService courseService, IOrderService orderService)
        {
            _courseService = courseService;
            _orderService = orderService;
        }

        public async Task OnGetAsync()
        {
            // Fetch the data for the charts
            Courses = await _courseService.GetAllCourses();
            Orders = await _orderService.GetDailyOrderCounts();
            TotalCourses = await _courseService.GetTotalCourses();
            TotalOrders = await _orderService.GetTotalOrders();
            CourseCountsByCategory = await _courseService.GetCourseCountsByCategory();
        }
    }
}
