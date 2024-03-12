using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Response.Order;
using App_BusinessObject.Paginate;
using App_DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Repository
{
    public interface IOrderRepository
    {
        public Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size);
        public void CreateOrder(CreateOrderRequest createOrderRequest);
        public Task<UpdateOrderResponse> UpdateOrder(int orderId, UpdateOrderRequest updateOrderRequest);
    }

    public class OrderRepository : IOrderRepository
    {
        public async Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size) => await OrderDAO.Instance.GetAllOrders(page, size);
        public void CreateOrder(CreateOrderRequest createOrderRequest) => OrderDAO.Instance.CreateOrder(createOrderRequest);
        public async Task<UpdateOrderResponse> UpdateOrder(int orderId, UpdateOrderRequest updateOrderRequest) => await OrderDAO.Instance.UpdateOrder(orderId, updateOrderRequest);
    }
}
