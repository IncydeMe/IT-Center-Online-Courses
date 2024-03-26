using App_BusinessObject.DTOs.Request.OrderDetail;
using App_BusinessObject.DTOs.Response.OrderDetail;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_DataAccessObject;
using App_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public async Task<IPaginate<GetOrderDetailResponse>> GetAllOrderDetails(int page, int size) 
            => await OrderDetailDAO.Instance.GetAllOrderDetails(page, size);
        public async Task<IPaginate<GetOrderDetailResponse>> GetOrderDetailsInOrder(int orderId, int page, int size) 
            => await OrderDetailDAO.Instance.GetOrderDetailsInOrder(orderId, page, size);
        public async Task CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest) 
            => await OrderDetailDAO.Instance.CreateOrderDetail(createOrderDetailRequest);
        public async Task<List<OrderDetail>> GetOrderDetaiListlInOrder(int orderId)
            => await OrderDetailDAO.Instance.GetOrderDetaiListlInOrder(orderId);
        public async Task<List<GetBestSellerCourseInOrderDetail>> GetBestSeller()
            => await OrderDetailDAO.Instance.GetBestSeller();
    }
}
