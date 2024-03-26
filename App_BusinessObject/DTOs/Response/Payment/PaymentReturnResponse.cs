using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.Payment
{
    public class PaymentReturnResponse
    {
        public int OrderId { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PaymentMessage { get; set; }
        public decimal? Amount { get; set; }
    }
}
