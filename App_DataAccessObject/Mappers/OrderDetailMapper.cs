using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Request.OrderDetail;
using App_BusinessObject.DTOs.Response.Order;
using App_BusinessObject.DTOs.Response.OrderDetail;
using App_BusinessObject.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject.Mappers
{
    public class OrderDetailMapper : Profile
    {
        public OrderDetailMapper() 
        {
            CreateMap<CreateOrderDetailRequest, OrderDetail>();
            CreateMap<OrderDetail, UpdateOrderDetailResponse>();
        }
    }
}
