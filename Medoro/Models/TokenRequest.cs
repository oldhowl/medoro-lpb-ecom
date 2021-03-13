using System;
using System.Xml.Serialization;
using Medoro.Exceptions;

namespace Medoro.Models
{
    [XmlRoot(ElementName = "Card")]
    public class Card
    {
        [XmlElement(ElementName = "Token")] public string Token { get; set; }
        [XmlElement(ElementName = "CSC")] public string Csc { get; set; }
        [XmlElement(ElementName = "Name")] public string Name { get; set; }
        [XmlElement(ElementName = "Number")] public string Number { get; set; }
        [XmlElement(ElementName = "Expiry")] public string Expiry { get; set; }

        public static Card CreateByToken(string token, string csc)
        {
            return new Card()
            {
                Token = token,
                Csc = csc
            };
        }

        public static Card CreateByNewCard(string name, string number, int month, int year, int csc, string token = null)
        {
            if (string.IsNullOrEmpty(name))
                throw new MedoroModelValidationException(nameof(name), "Can not be null or empty");

            if (string.IsNullOrEmpty(number))
                throw new MedoroModelValidationException(nameof(number), "Can not be null or empty");

            if (name.Length > 50)
                throw new MedoroModelValidationException(nameof(name), "Name length can't be greater than 50");

            var expiredDate = new DateTime(int.Parse($"{(DateTime.Now.Year / 100)}" + $"{year}"), month, 1);
            
            if (DateTime.Now.Date > expiredDate)
                throw new MedoroModelValidationException("Card expired");

            if (csc > 999)
                throw new MedoroModelValidationException(nameof(csc), "Wrong csc");

            return new Card()
            {
                Csc = csc.ToString("000"),
                Expiry = $"{year:00}{month:00}",
                Name = name,
                Number = number,
                Token = token
            };
        }
        private Card()
        {
        }
    }

    [XmlRoot(ElementName = "data")]
    public class TokenRequest
    {
        [XmlElement(ElementName = "Card")] public Card Card { get; set; }

        public TokenRequest(Card card)
        {
            Card = card;
        }

        private TokenRequest()
        {
        }
    }
}