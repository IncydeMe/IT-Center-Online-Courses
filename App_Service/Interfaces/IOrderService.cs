using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Response.Order;
using App_BusinessObject.Paginate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface IOrderService
    {
        public Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size);
        public Task<IPaginate<GetOrderResponse>> GetUserOrderList(int accountId, int page, int size);
        public Task<GetOrderResponse> GetOrderById(int orderId);
        public Task CreateOrder(CreateOrderRequest createOrderRequest);
        public Task<bool> ChangeStatus(int orderId);
        public Task<Dictionary<string, int>> GetMonthlyOrderCounts();
        public Task<int> GetTotalOrders();
        public Task<Dictionary<string, int>> GetDailyOrderCounts();
        public Task<Dictionary<string, double>> GetDailyRevenue(int month, int year);
    }
}
