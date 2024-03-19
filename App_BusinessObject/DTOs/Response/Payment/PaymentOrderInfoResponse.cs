using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_BusinessObject.DTOs.Response.Payment
{
    public class PaymentOrderInfoResponse
    {
        public int ItemAmount { get; set; }
        public double TotalPrice { get; set; }
    }
}
