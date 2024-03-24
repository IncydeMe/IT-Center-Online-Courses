﻿using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Response.Order;
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
        public Task<GetOrderResponse> GetOrderById(int orderId) => OrderDAO.Instance.GetOrderById(orderId);
        public async Task CreateOrder(CreateOrderRequest createOrderRequest) => await OrderDAO.Instance.CreateOrder(createOrderRequest);
        public async Task<bool> ChangeStatus(int orderId) => await OrderDAO.Instance.ChangeStatus(orderId);
    }
}