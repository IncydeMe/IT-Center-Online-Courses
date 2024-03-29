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
using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Request.OrderDetail;
using App_BusinessObject.DTOs.Response.Payment;
using App_Service.Services;
using System.Drawing.Printing;

namespace IT_Center_Website.Pages.Courses
{
	public class IndexModel : PageModel
	{
		private readonly IOrderService _orderService;
		private readonly IOrderDetailService _orderDetailService;
		private readonly ICourseService _courseService;
		private readonly IPaymentService _paymentService;
		private readonly int size = 3;

		public IndexModel(ICourseService courseService, IOrderService orderService, IOrderDetailService orderDetailService,
			IPaymentService paymentService)
		{
			_courseService = courseService;
			_orderService = orderService;
			_orderDetailService = orderDetailService;
			_paymentService = paymentService;
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
            TotalPages = courses.TotalPages;
            this.PageNumber = courses.Page;

            if (courses.Items != null)
			{
				Course = (List<GetCourseResponse>)courses.Items;
			}
		}

		public async Task<IActionResult> OnPostAsync(int id)
		{
			Order createdOrder = await _orderService.CreateOrder((int)HttpContext.Session.GetInt32("Id"));

			await _orderDetailService.CreateOrderDetail(new CreateOrderDetailRequest
			{
				OrderId = createdOrder.OrderId,
				CourseIds = new List<int> { id }
			});

			PaymentLinkResponse response = await _paymentService.CreatePayment(createdOrder);

			return Redirect(response.PaymentUrl);
		}
	}
}
