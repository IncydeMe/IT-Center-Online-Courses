using App_BusinessObject.DTOs.Request.OrderDetail;
using App_BusinessObject.DTOs.Response.OrderDetail;
using App_BusinessObject.Paginate;
using App_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository
{
    public interface IOrderDetailRepository
    {
        public Task<IPaginate<GetOrderDetailResponse>> GetAllOrderDetails(int page, int size);
        public Task<List<GetOrderDetailResponse>> GetOrderDetailsInOrder(int orderId);
        public void CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest);
        
    }

    public class OrderDetailRepository : IOrderDetailRepository
    {
        public async Task<IPaginate<GetOrderDetailResponse>> GetAllOrderDetails(int page, int size) => await OrderDetailDAO.Instance.GetAllOrderDetails(page, size);
        public async Task<List<GetOrderDetailResponse>> GetOrderDetailsInOrder(int orderId) => await OrderDetailDAO.Instance.GetOrderDetailsInOrder(orderId);
        public void CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest) => OrderDetailDAO.Instance.CreateOrderDetail(createOrderDetailRequest);
    }
}
