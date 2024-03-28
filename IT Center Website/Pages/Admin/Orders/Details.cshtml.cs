using App_BusinessObject.DTOs.Response.Course;
using App_BusinessObject.DTOs.Response.Order;
using App_BusinessObject.Models;
using App_Service.Interfaces;
using App_Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages.Admin.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly ICourseService _courseService;

        public DetailsModel(IOrderService orderService, IOrderDetailService orderDetailService,
            ICourseService courseService)
        {
            _courseService = courseService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        [BindProperty]
        public GetOrderResponse Order { get; set; }

        public List<GetCourseResponse> Courses { get; set; }
        public double TotalPrice { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            TotalPrice = 0;
            if (await _orderService.GetOrderById(id) == null)
            {
                return NotFound();
            }
            Order = await _orderService.GetOrderById(id);

            var orderDetails = await _orderDetailService.GetOrderDetaiListlInOrder(Order.OrderId);

            foreach (var orderDetail in orderDetails)
            {
                var course = await _courseService.GetCourseById(orderDetail.CourseId);
                Courses.Add(course);
                TotalPrice += course.Price;
            }

            return Page();
        }
    }
}
