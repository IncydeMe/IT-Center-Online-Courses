using App_BusinessObject.DTOs.Request.OwnedCourse;
using App_Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Payment.Domain.VNPay.Response;
using static Google.Apis.Requests.BatchRequest;

namespace IT_Center_Website.Pages
{
    public class PaymentReturnModel : PageModel
    {
        private readonly IPaymentService _paymentService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOwnedCourseService _ownedCourseService;
        private readonly IOwnedLessonService _ownedLessonService;

        public PaymentReturnModel(IPaymentService paymentService, IOrderService orderService,
            IOrderDetailService orderDetailService, IOwnedLessonService ownedLessonService,
            IOwnedCourseService ownedCourseService)
        {
            _paymentService = paymentService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _ownedCourseService = ownedCourseService;
            _ownedLessonService = ownedLessonService;
        }

        [BindProperty(SupportsGet = true)]
        public VNPayResponse VNPayResponse { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var result = await _paymentService.CheckPaymentResponse(VNPayResponse);

            var order = await _orderService.GetOrderById(result.OrderId);
            int accountId = order.AccountId;

            //Check is payment (order) paid successfully
            if (result.PaymentStatus.Equals("Success"))
            {
                //Change Order status => True
                await _orderService.ChangeStatus(result.OrderId);

                //Add Course and lesson in orderDetail to OwnCourse, OwnLesson
                foreach (var orderDetail in _orderDetailService.GetOrderDetaiListlInOrder(result.OrderId).Result)
                {
                    await _ownedCourseService.CreateOwnedCourse(new CreateOwnedCourseRequest()
                    {
                        AccountId = accountId,
                        CourseId = orderDetail.CourseId
                    });

                    await _ownedLessonService.CreateOwnedLesson(orderDetail.CourseId, accountId);
                }

            }
            return RedirectToPage("/Courses");
        }
    }
}
