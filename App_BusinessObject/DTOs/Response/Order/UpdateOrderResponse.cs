using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.Order
{
    public class UpdateOrderResponse
    {
        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
