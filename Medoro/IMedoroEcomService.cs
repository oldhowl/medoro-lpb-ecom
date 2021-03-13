using System;
using System.Threading.Tasks;
using Medoro.Models;

namespace Medoro
{
    public interface IMedoroEcomService
    {
        Task<PaymentResponse> PaymentMode6(
            bool isAutoDeposit,
            string descriptor,
            object orderId,
            decimal amount,
            string currency,
            string orderDescription,
            Card card,
            string payerName,
            string payerAddress,
            string payerCity,
            string payerCountry,
            string payerZip,
            string payerPhone,
            string payerEmail,
            string notification,
            int? frequency = null,
            DateTime? endDate = null
        );

        Task<PaymentResponse> AuthorizePayment(string paymentId, string paRes);
    }
}