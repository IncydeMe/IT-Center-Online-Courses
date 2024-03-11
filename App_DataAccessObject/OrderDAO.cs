using App_BusinessObject.DTOs.Request.Category;
using App_BusinessObject.DTOs.Request.Course;
using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Response.Account;
using App_BusinessObject.DTOs.Response.Course;
using App_BusinessObject.DTOs.Response.Order;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_DataAccessObject.Mappers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject
{
    public class OrderDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper = null;

        private static OrderDAO instance;        
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }
                return instance;
            }
        }

        private OrderDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if (_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new OrderMapper())).CreateMapper().ConfigurationProvider);
        }

        #region OrderFunction
        public async Task<IPaginate<GetOrderResponse>> GetAllOrders(int page, int size)
        {
            IPaginate<GetOrderResponse> orderList = await _dbContext.Orders.Select(x => new GetOrderResponse
            {
                OrderId = x.OrderId,
                CreatedDate = x.CreatedDate,
                Status = x.Status,
                Account = x.Account.AccountId
            }).ToPaginateAsync(page, size, 1);
            return orderList;
        }
        #endregion

        public async void CreateOrder(CreateOrderRequest createOrderRequest)
        {
                _dbContext.Orders.Add(_mapper.Map<Order>(createOrderRequest));
                await _dbContext.SaveChangesAsync();
        }

        public async Task<UpdateOrderResponse> UpdateOrder(int orderId, UpdateOrderRequest updateOrderRequest)
        {
            Order order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);

            if (order != null)
            {
                order.OrderId = orderId;
                order.CreatedDate = DateTime.Now;
                order.Status = updateOrderRequest.Status;
                _dbContext.Orders.Update(order);
                await _dbContext.SaveChangesAsync();

                UpdateOrderResponse response = _mapper.Map<UpdateOrderResponse>(order);
                return response;
            }
            return null;
        }
    }
}