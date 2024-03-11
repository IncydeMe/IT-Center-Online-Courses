using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.OrderDetail
{
    public class UpdateOrderDetailResponse
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CourseId { get; set; }
    }
}
