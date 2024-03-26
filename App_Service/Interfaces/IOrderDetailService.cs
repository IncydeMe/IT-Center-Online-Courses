using App_BusinessObject.DTOs.Request.OrderDetail;
using App_BusinessObject.DTOs.Response.OrderDetail;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface IOrderDetailService
    {
        public Task<IPaginate<GetOrderDetailResponse>> GetAllOrderDetails(int page, int size);
        public Task<IPaginate<GetOrderDetailResponse>> GetOrderDetailsInOrder(int orderId, int page, int size);
        public Task CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest);
        public Task<List<OrderDetail>> GetOrderDetaiListlInOrder(int orderId);
        public Task<List<GetBestSellerCourseInOrderDetail>> GetBestSeller();
    }
}
