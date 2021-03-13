using System.Xml.Serialization;

namespace Medoro.Models
{
    [XmlRoot(ElementName = "Payment")]
    public class PaymentAuthenticate
    {
        [XmlElement(ElementName = "ID")] public string ID { get; set; }
    }

    
    [XmlRoot(ElementName = "Order")]
    public class OrderAuthenticate
    {
        [XmlElement(ElementName = "ID")] public string ID { get; set; }
    }
    
    [XmlRoot(ElementName = "ACS")]
    public class ACSAuthenticate
    {
        [XmlElement(ElementName = "PaRes")] public string PaRes { get; set; }
    }

    [XmlRoot(ElementName = "D3D")]
    public class D3DAuthenticate
    {
        [XmlElement(ElementName = "ACS")] public ACSAuthenticate ACS { get; set; }
    }

    [XmlRoot(ElementName = "data")]
    public class AuthenticateData 
    {
        [XmlElement(ElementName = "Payment")] public PaymentAuthenticate Payment { get; set; }
        [XmlElement(ElementName = "D3D")] public D3DAuthenticate D3D { get; set; }

        public AuthenticateData(string paymentId, string paRes)
        {
            Payment = new PaymentAuthenticate()
            {
                ID = paymentId
            };

            D3D = new D3DAuthenticate()
            {
                ACS = new ACSAuthenticate()
                {
                    PaRes = paRes
                }
            };
        }
        
        private AuthenticateData(){}
    }
}