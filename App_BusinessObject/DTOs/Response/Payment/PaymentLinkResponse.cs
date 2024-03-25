using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.Payment
{
    public class PaymentLinkResponse
    {
        public int OrderId { get; set; }
        public string PaymentUrl { get; set; } = string.Empty;
    }
}
