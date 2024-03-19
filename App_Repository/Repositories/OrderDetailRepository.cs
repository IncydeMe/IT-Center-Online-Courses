﻿using App_BusinessObject.DTOs.Request.OrderDetail;
using App_BusinessObject.DTOs.Response.OrderDetail;
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
        public async Task<IPaginate<GetOrderDetailResponse>> GetAllOrderDetails(int page, int size) => await OrderDetailDAO.Instance.GetAllOrderDetails(page, size);
        public async Task<List<GetOrderDetailResponse>> GetOrderDetailsInOrder(int orderId) => await OrderDetailDAO.Instance.GetOrderDetailsInOrder(orderId);
        public async Task CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest) => await OrderDetailDAO.Instance.CreateOrderDetail(createOrderDetailRequest);
    }
}
