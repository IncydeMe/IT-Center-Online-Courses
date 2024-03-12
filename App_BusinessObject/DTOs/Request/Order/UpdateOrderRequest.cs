using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Request.Order
{
    public class UpdateOrderRequest
    {
        public int AccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
