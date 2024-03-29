using App_BusinessObject.DTOs.Response.Account;
using App_BusinessObject.Models;
using App_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IT_Center_Website.Pages.Admin.Orders
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly IOrderService _orderService;
		private readonly IOrderDetailService _orderDetailService;
		private readonly ICourseService _courseService;
		private int size = 10;

		public IndexModel(ILogger<IndexModel> logger, IOrderService orderService,
			IOrderDetailService orderDetailService, ICourseService courseService)
		{
			_logger = logger;
			_orderService = orderService;
			_orderDetailService = orderDetailService;
			_courseService = courseService;
		}

		[BindProperty]
		public List<Order> Orders { get; set; }
		public double TotalPrice { get; set; }

		[BindProperty(SupportsGet = true)]
		public int PageNumber { get; set; }
		public int TotalPages { get; set; }

		public async Task OnGetAsync()
		{
			TotalPrice = 0;
			if (PageNumber == 0)
			{
				PageNumber = 1;
			}

			var orders = await _orderService.GetAllOrders(PageNumber, size);
			TotalPages = orders.TotalPages;
			this.PageNumber = orders.Page;

			if (orders != null)
			{
				Orders = (List<Order>)orders.Items;
			}

			foreach (var order in Orders)
			{
				foreach (var orderDetail in await _orderDetailService.GetOrderDetaiListlInOrder(order.OrderId))
				{
					TotalPrice += _courseService.GetCourseById(orderDetail.CourseId).Result.Price;
				}
			}
		}
	}
}
