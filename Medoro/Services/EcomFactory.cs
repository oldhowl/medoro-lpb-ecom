using System;
using Medoro.Exceptions;
using Medoro.Models;

namespace Medoro.Services
{
    public class EcomFactory
    {
        public static PaymentData CreatePaymentData(
            bool isAutoDeposit,
            int mode,
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
            DateTime? endDate = null)
        {
            if (mode < 1 || mode > 9) throw new MedoroModelValidationException(nameof(mode));
            if (descriptor == null) throw new MedoroModelValidationException(nameof(descriptor));
            if (orderId == null) throw new MedoroModelValidationException(nameof(orderId));
            if (currency == null) throw new MedoroModelValidationException(nameof(currency));
            if (orderDescription == null) throw new MedoroModelValidationException(nameof(orderDescription));
            if (card == null) throw new MedoroModelValidationException(nameof(card));
            if (payerName == null) throw new MedoroModelValidationException(nameof(payerName));
            if (payerAddress == null) throw new MedoroModelValidationException(nameof(payerAddress));
            if (payerCity == null) throw new MedoroModelValidationException(nameof(payerCity));
            if (payerCountry == null) throw new MedoroModelValidationException(nameof(payerCountry));
            if (payerZip == null) throw new MedoroModelValidationException(nameof(payerZip));
            if (payerPhone == null) throw new MedoroModelValidationException(nameof(payerPhone));
            if (payerEmail == null) throw new MedoroModelValidationException(nameof(payerEmail));
            if (notification == null) throw new MedoroModelValidationException(nameof(notification));
            var recurring = frequency.HasValue && endDate.HasValue
                ? new Recurring(frequency.Value, endDate.Value)
                : null;

            return new PaymentData(
                isAutoDeposit,
                new Payment(mode, descriptor),
                recurring,
                new Order(orderId, amount, currency, orderDescription),
                card,
                new BillingAddress(payerName, payerAddress, payerCity, payerCountry, payerZip, payerPhone, payerEmail),
                notification
            );
        }
    }
}