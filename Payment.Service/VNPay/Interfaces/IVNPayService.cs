using Payment.Domain.VNPay.Request;
using Payment.Domain.VNPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Service.VNPay.Interfaces
{
    public interface IVNPayService
    {
        public Task<string> GetPaymentLink(string baseUrl, string secretKey, VNPayRequest request);
        public Task<bool> IsValidSignature(string secretKey, VNPayResponse response);
    }
}
