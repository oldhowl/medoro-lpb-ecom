using System;
using System.Xml.Serialization;

namespace Medoro.Models
{
    [XmlRoot(ElementName = "Payment")]
    public class Payment
    {
        [XmlElement(ElementName = "Mode")] public string Mode { get; set; }

        [XmlElement(ElementName = "Descriptor")]
        public string Descriptor { get; set; }

        public Payment(int mode, string descriptor)
        {
            Mode = mode.ToString();
            Descriptor = descriptor;
        }

        private Payment(){}
    }

    [XmlRoot(ElementName = "Recurring")]
    public class Recurring
    {
        [XmlElement(ElementName = "Frequency")]
        public string Frequency { get; set; }

        [XmlElement(ElementName = "EndDate")] public string EndDate { get; set; }

        public Recurring(int frequency, DateTime endDate)
        {
            Frequency = frequency.ToString();
            EndDate = endDate.ToString("yyyyMMdd");
        }
        
        private Recurring(){}
    }

    [XmlRoot(ElementName = "Order")]
    public class Order
    {
        [XmlElement(ElementName = "ID")] public string Id { get; set; }
        [XmlElement(ElementName = "Amount")] public string Amount { get; set; }
        [XmlElement(ElementName = "Currency")] public string Currency { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }


        public Order(object id, decimal amount, string currency, string description)
        {
            Id = id.ToString();
            Amount = (amount * 100).ToString("");
            Currency = currency;
            Description = description;
        }
        private Order(){}
    }


    [XmlRoot(ElementName = "BillingAddress")]
    public class BillingAddress
    {
        [XmlElement(ElementName = "Name")] public string Name { get; set; }
        [XmlElement(ElementName = "Address")] public string Address { get; set; }
        [XmlElement(ElementName = "City")] public string City { get; set; }
        [XmlElement(ElementName = "Country")] public string Country { get; set; }

        [XmlElement(ElementName = "PostIndex")]
        public string PostIndex { get; set; }

        [XmlElement(ElementName = "Phone")] public string Phone { get; set; }
        [XmlElement(ElementName = "Email")] public string Email { get; set; }

        public BillingAddress(string name, string address, string city, string country, string postIndex, string phone, string email)
        {
            Name = name;
            Address = address;
            City = city;
            Country = country;
            PostIndex = postIndex;
            Phone = phone;
            Email = email;
        }
        
        private BillingAddress(){}
    }

    [XmlRoot(ElementName = "data")]
    public class PaymentData
    {
        [XmlElement(ElementName = "AutoDeposit")]
        public bool AutoDeposit { get; set; }

        [XmlElement(ElementName = "Payment")] public Payment Payment { get; set; }

        [XmlElement(ElementName = "Recurring")]
        public Recurring Recurring { get; set; }

        [XmlElement(ElementName = "Order")] public Order Order { get; set; }
        [XmlElement(ElementName = "Card")] public Card Card { get; set; }

        [XmlElement(ElementName = "BillingAddress")]
        public BillingAddress BillingAddress { get; set; }

        [XmlElement(ElementName = "Notification")]
        public string Notification { get; set; }

        public PaymentData(bool autoDeposit, Payment payment, Recurring recurring, Order order,  BillingAddress billingAddress, string notification, Card card = null)
        {
            AutoDeposit = autoDeposit;
            Card = card;
            Payment = payment;
            Recurring = recurring;
            Order = order;
            BillingAddress = billingAddress;
            Notification = notification;
        }
        
        private PaymentData(){}
    }
}