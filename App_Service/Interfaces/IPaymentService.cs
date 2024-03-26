using App_BusinessObject.DTOs.Response.Payment;
using App_BusinessObject.Models;
using Payment.Domain.VNPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.Interfaces
{
    public interface IPaymentService
    {
        public Task<PaymentLinkResponse> CreatePayment(Order order);
        public Task<PaymentReturnResponse> CheckPaymentResponse(VNPayResponse response);
    }
}
