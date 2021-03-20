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
            string payerName,
            string payerAddress,
            string payerCity,
            string payerCountry,
            string payerZip,
            string payerPhone,
            string payerEmail,
            string notification,
            Card card = null,
            int? frequency = null,
            DateTime? endDate = null
        );
        Task<PaymentPayload> PaymentMode5(
            bool isAutoDeposit,
            string descriptor,
            object orderId,
            decimal amount,
            string currency,
            string orderDescription,
            string payerName,
            string payerAddress,
            string payerCity,
            string payerCountry,
            string payerZip,
            string payerPhone,
            string payerEmail,
            string notification,
            Card card = null,
            int? frequency = null,
            DateTime? endDate = null
        );

        Task<PaymentResponse> AuthorizeSoapPayment(string paymentId, string paRes);
        PaymentResponse AuthorizeFormPayment(string data, string key);
    }
}