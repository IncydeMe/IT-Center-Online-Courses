using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.Order
{
    public class GetOrderResponse
    {
        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int AccountId { get; set; }

        public GetOrderResponse()
        {

        }

        public GetOrderResponse(int orderId, DateTime createdDate, bool status, int accountId)
        {
            OrderId = orderId;
            CreatedDate = createdDate;
            Status = status;
            AccountId = accountId;
        }
    }
}
