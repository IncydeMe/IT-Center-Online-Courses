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
        public Task<IPaginate<GetOrderResponse>> GetUserOrderList(int accountId, int page, int size);
        public Task<GetOrderResponse> GetOrderById(int orderId);
        public Task CreateOrder(CreateOrderRequest createOrderRequest);
        public Task<bool> ChangeStatus(int orderId);
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
        public async Task<IPaginate<GetOrderResponse>> GetUserOrderList(int accountId, int page, int size) => await _orderRepository.GetUserOrderList(accountId, page, size);
        public Task<GetOrderResponse> GetOrderById(int orderId) => _orderRepository.GetOrderById(orderId);
        public async Task CreateOrder(CreateOrderRequest createOrderRequest) => await _orderRepository.CreateOrder(createOrderRequest);
        public async Task<bool> ChangeStatus(int orderId) => await _orderRepository.ChangeStatus(orderId);
    }
}
