using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Response.Order;
using App_BusinessObject.Paginate;
using App_Repository.Interfaces;
using App_Repository.Repositories;
using App_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size) => await _orderRepository.GetAllOrders(page, size);
        public async Task<IPaginate<GetOrderResponse>> GetUserOrderList(int accountId, int page, int size) => await _orderRepository.GetUserOrderList(accountId, page, size);
        public async Task<GetOrderResponse> GetOrderById(int orderId) => await _orderRepository.GetOrderById(orderId);
        public async Task CreateOrder(CreateOrderRequest createOrderRequest) => await _orderRepository.CreateOrder(createOrderRequest);
        public async Task<bool> ChangeStatus(int orderId) => await _orderRepository.ChangeStatus(orderId);
        public async Task<Dictionary<string, int>> GetMonthlyOrderCounts() => await _orderRepository.GetMonthlyOrderCounts();
        public async Task<int> GetTotalOrders() => await _orderRepository.GetTotalOrders();
        public async Task<Dictionary<string, int>> GetDailyOrderCounts() => await _orderRepository.GetDailyOrderCounts();
        public async Task<Dictionary<string, double>> GetDailyRevenue(int month, int year) 
            => await _orderRepository.GetDailyRevenue(month, year);
    }
}
