using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.OrderDetail
{
    public class GetOrderDetailResponse
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CourseId { get; set; }

        public GetOrderDetailResponse()
        {

        }

        public GetOrderDetailResponse(int orderDetailId, int orderId, int courseId)
        {
            OrderDetailId = orderDetailId;
            OrderId = orderId;
            CourseId = courseId;
        }
    }
}
