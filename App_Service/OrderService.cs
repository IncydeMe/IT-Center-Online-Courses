using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Response.Order;
using App_BusinessObject.Paginate;
using App_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service
{
    public interface IOrderService
    {
        public Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size);
        public void CreateOrder(CreateOrderRequest createOrderRequest);
        public Task<UpdateOrderResponse> UpdateOrder(int orderId, UpdateOrderRequest updateOrderRequest);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService()
        {
            if (_orderRepository == null)
                _orderRepository = new OrderRepository();
        }
        public async Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size) => await _orderRepository.GetAllOrders(page, size);
        public void CreateOrder(CreateOrderRequest createOrderRequest) => _orderRepository.CreateOrder(createOrderRequest);
        public async Task<UpdateOrderResponse> UpdateOrder(int orderId, UpdateOrderRequest updateOrderRequest) => await _orderRepository.UpdateOrder(orderId,updateOrderRequest);
    }
}
