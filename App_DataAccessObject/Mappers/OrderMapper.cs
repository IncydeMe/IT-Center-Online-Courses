using App_BusinessObject.DTOs.Request.Course;
using App_BusinessObject.DTOs.Request.Order;
using App_BusinessObject.DTOs.Response.Course;
using App_BusinessObject.DTOs.Response.Order;
using App_BusinessObject.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_DataAccessObject.Mappers
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<Order, UpdateOrderResponse>();
        }
    }
}
