using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Response.Order;
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
    public class OrderRepository : IOrderRepository
    {
        public async Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size) => await OrderDAO.Instance.GetAllOrders(page, size);
        public async Task<IPaginate<GetOrderResponse>> GetUserOrderList(int accountId, int page, int size) => await OrderDAO.Instance.GetAllOrders(page, size);
        public async Task<GetOrderResponse> GetOrderById(int orderId) => await OrderDAO.Instance.GetOrderById(orderId);
        public async Task<Order> CreateOrder(int accountId) => await OrderDAO.Instance.CreateOrder(accountId);
        public async Task<bool> ChangeStatus(int orderId) => await OrderDAO.Instance.ChangeStatus(orderId);
        public async Task<Dictionary<string, int>> GetMonthlyOrderCounts() => await OrderDAO.Instance.GetMonthlyOrderCounts();
        public async Task<int> GetTotalOrders() => await OrderDAO.Instance.GetTotalOrders();
        public async Task<Dictionary<string, int>> GetDailyOrderCounts() => await OrderDAO.Instance.GetDailyOrderCounts();
        public async Task<Dictionary<string, double>> GetDailyRevenue(int month, int year) 
            => await OrderDAO.Instance.GetDailyRevenue(month, year);
    }
}
