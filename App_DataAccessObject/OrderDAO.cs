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
                AccountId = x.AccountId

            }).ToPaginateAsync(page, size, 1);
            return orderList;
        }

        public async Task<IPaginate<GetOrderResponse>> GetUserOrderList(int accountId, int page, int size)
        {
            IPaginate<GetOrderResponse> userOrderList = await _dbContext.Orders
                .Where(x => x.AccountId == accountId)
                .Select(x => new GetOrderResponse
                {
                    OrderId = x.OrderId,
                    CreatedDate = x.CreatedDate,
                    Status = x.Status,
                    AccountId = x.AccountId
                })
                .ToPaginateAsync(page, size, 1);
            return userOrderList;
        }

        public async Task<GetOrderResponse> GetOrderById(int orderId)
        {
            Order? order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (order == null)
            {
                return null;
            }
                GetOrderResponse response = _mapper.Map<GetOrderResponse>(order);
                return response;
        }

        public async Task CreateOrder(CreateOrderRequest createOrderRequest)
        {
            await _dbContext.Orders.AddAsync(_mapper.Map<Order>(createOrderRequest));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ChangeStatus(int orderId)
        {
            Order? order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
            if (order == null)
            {
                return false;
            }
                order.Status = !order.Status;
                _dbContext.Orders.Update(order);
                await _dbContext.SaveChangesAsync();
                return true;
        }
        #endregion
    }
}