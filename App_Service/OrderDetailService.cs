﻿using App_BusinessObject.DTOs.Request.OrderDetail;
using App_BusinessObject.DTOs.Response.OrderDetail;
using App_BusinessObject.Paginate;
using App_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service
{
    public interface IOrderDetailService
    {
        public Task<IPaginate<GetOrderDetailResponse>> GetAllOrderDetails(int page, int size);
        public void CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest);
        public Task<UpdateOrderDetailResponse> UpdateOrderDetail(int orderDetailId, UpdateOrderDetailRequest updateOrderDetailRequest);
    }

    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService()
        {
            if (_orderDetailRepository == null)
                _orderDetailRepository = new OrderDetailRepository();
        }

        public async Task<IPaginate<GetOrderDetailResponse>> GetAllOrderDetails(int page, int size) => await _orderDetailRepository.GetAllOrderDetails(page, size);
        public void CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest) => _orderDetailRepository.CreateOrderDetail(createOrderDetailRequest);
        public async Task<UpdateOrderDetailResponse> UpdateOrderDetail(int orderDetailId, UpdateOrderDetailRequest updateOrderDetailRequest) => await _orderDetailRepository.UpdateOrderDetail(orderDetailId, updateOrderDetailRequest);
    }
}