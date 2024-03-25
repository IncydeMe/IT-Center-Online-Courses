using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Request.OrderDetail;
using App_BusinessObject.DTOs.Response.Order;
using App_BusinessObject.DTOs.Response.OrderDetail;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_DataAccessObject.Mappers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject
{
    public class OrderDetailDAO
    {
        private readonly ITCenterContext _dbContext = null;
        private readonly IMapper _mapper = null;

        private static OrderDetailDAO instance;
        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }
                return instance;
            }
        }

        private OrderDetailDAO()
        {
            if (_dbContext == null)
                _dbContext = new ITCenterContext();
            if (_mapper == null)
                _mapper = new Mapper(new MapperConfiguration(mc => mc.AddProfile(new OrderDetailMapper())).CreateMapper().ConfigurationProvider);
        }

        #region OrderDetailFunction
        public async Task<IPaginate<GetOrderDetailResponse>> GetAllOrderDetails(int page, int size)
        {
            IPaginate<GetOrderDetailResponse> orderDetailList = await _dbContext.OrderDetails.Select(x => new GetOrderDetailResponse
            {
                OrderDetailId = x.OrderDetailId,
                OrderId = x.OrderId,
                CourseId = x.CourseId

            }).ToPaginateAsync(page, size, 1);
            return orderDetailList;
        }
      
        public async Task<List<GetOrderDetailResponse>> GetOrderDetailsInOrder(int orderId)
        {
            List<GetOrderDetailResponse> orderDetails = await _dbContext.OrderDetails
                .Where(x => x.OrderId == orderId)
                .Select(x => new GetOrderDetailResponse
                {
                    OrderDetailId = x.OrderDetailId,
                    OrderId = x.OrderId,
                    CourseId = x.CourseId
                })
                .ToListAsync();
            return orderDetails;
        }

        public async Task CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest)
        {
            await _dbContext.OrderDetails.AddAsync(_mapper.Map<OrderDetail>(createOrderDetailRequest));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<OrderDetail>> GetOrderDetaiListlInOrder(int orderId)
        {
            return await _dbContext.OrderDetails.Where(odd => odd.OrderId == orderId).ToListAsync();
        }

        public async Task<List<GetBestSellerCourseInOrderDetail>> GetBestSeller()
        {
            return await _dbContext.OrderDetails.GroupBy(ord => ord.CourseId)
                                 .Select(ord => new GetBestSellerCourseInOrderDetail
                                 {
                                     Id = ord.Key,
                                     Count = ord.Count(),
                                 })
                                 .OrderByDescending(ord => ord.Count)
                                 .Take(3).ToListAsync();
        }
        #endregion
    }
}
