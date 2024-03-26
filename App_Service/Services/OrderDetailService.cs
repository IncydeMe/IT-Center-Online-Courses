using App_BusinessObject.DTOs.Request.OrderDetail;
using App_BusinessObject.DTOs.Response.OrderDetail;
using App_BusinessObject.Models;
using App_BusinessObject.Paginate;
using App_Repository.Interfaces;
using App_Repository.Repositories;
using App_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<IPaginate<GetOrderDetailResponse>> GetAllOrderDetails(int page, int size)
            => await _orderDetailRepository.GetAllOrderDetails(page, size);
        public async Task<IPaginate<GetOrderDetailResponse>> GetOrderDetailsInOrder(int orderId, int page, int size) 
            => await _orderDetailRepository.GetOrderDetailsInOrder(orderId, page, size);
        public async Task CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest) 
            => await _orderDetailRepository.CreateOrderDetail(createOrderDetailRequest);
        public async Task<List<OrderDetail>> GetOrderDetaiListlInOrder(int orderId)
            => await _orderDetailRepository.GetOrderDetaiListlInOrder(orderId);
        public async Task<List<GetBestSellerCourseInOrderDetail>> GetBestSeller() 
            => await _orderDetailRepository.GetBestSeller();
    }
}
