namespace Medoro.Models
{
    public class PaymentPayload
    {
        public string Key { get; }
        public string KeyIndex { get; }
        public string Data { get; }
        public string Interface { get; }
        public string Signature { get; }

        public PaymentPayload(string key, string keyIndex, string data, string @interface, string signature)
        {
            Key = key;
            KeyIndex = keyIndex;
            Data = data;
            Interface = @interface;
            Signature = signature;
          
        }
    }
}