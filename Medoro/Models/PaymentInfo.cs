using System.Xml.Serialization;

namespace Medoro.Models
{
    [XmlRoot(ElementName = "Payment")]
    public class PaymentInfo
    {
        [XmlElement(ElementName = "ID")] public string ID { get; set; }
        [XmlElement(ElementName = "State")] public string State { get; set; }
        [XmlElement(ElementName = "Mode")] public string Mode { get; set; }

        [XmlElement(ElementName = "StartDate")]
        public string StartDate { get; set; }

        [XmlElement(ElementName = "LastDate")] public string LastDate { get; set; }

        [XmlElement(ElementName = "Descriptor")]
        public string Descriptor { get; set; }
    }

    [XmlRoot(ElementName = "Order")]
    public class OrderResponse
    {
        [XmlElement(ElementName = "ID")] public string ID { get; set; }
        [XmlElement(ElementName = "Amount")] public string Amount { get; set; }

        [XmlElement(ElementName = "ReversalAmount")]
        public string ReversalAmount { get; set; }

        [XmlElement(ElementName = "Currency")] public string Currency { get; set; }

        [XmlElement(ElementName = "Description")]
        public string Description { get; set; }
    }

    [XmlRoot(ElementName = "Card")]
    public class CardResponse
    {
        [XmlElement(ElementName = "Name")] public string Name { get; set; }
        [XmlElement(ElementName = "Number")] public string Number { get; set; }
    }

    [XmlRoot(ElementName = "BillingAddress")]
    public class BillingAddressResponse
    {
        [XmlElement(ElementName = "Name")] public string Name { get; set; }
        [XmlElement(ElementName = "Address")] public string Address { get; set; }
        [XmlElement(ElementName = "City")] public string City { get; set; }
        [XmlElement(ElementName = "Country")] public string Country { get; set; }

        [XmlElement(ElementName = "PostIndex")]
        public string PostIndex { get; set; }

        [XmlElement(ElementName = "Phone")] public string Phone { get; set; }
        [XmlElement(ElementName = "Email")] public string Email { get; set; }
    }

    [XmlRoot(ElementName = "ACS")]
    public class ACSResponse
    {
        [XmlElement(ElementName = "URL")] public string URL { get; set; }
        [XmlElement(ElementName = "PaReq")] public string PaReq { get; set; }
    }

    [XmlRoot(ElementName = "D3D")]
    public class D3DResponse
    {
        [XmlElement(ElementName = "Enrolled")] public string Enrolled { get; set; }
        [XmlElement(ElementName = "ACS")] public ACSResponse ACS { get; set; }
    }

    [XmlRoot(ElementName = "data"), XmlType("data")]
    public class PaymentResponse 
    {
        [XmlElement(ElementName = "AutoDeposit")]
        public string AutoDeposit { get; set; }

        [XmlElement(ElementName = "Payment")] public PaymentInfo Payment { get; set; }
        [XmlElement(ElementName = "Order")] public OrderResponse Order { get; set; }
        [XmlElement(ElementName = "Card")] public CardResponse Card { get; set; }

        [XmlElement(ElementName = "BillingAddress")]
        public BillingAddress BillingAddress { get; set; }

        [XmlElement(ElementName = "D3D")] public D3DResponse D3D { get; set; }

        [XmlElement(ElementName = "Notification")]
        public string Notification { get; set; }
    }
}