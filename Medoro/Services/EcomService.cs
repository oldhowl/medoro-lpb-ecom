using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medoro.Exceptions;
using Medoro.Models;
using Medoro.Services.CryptoServices;
using ServiceReference1;
using PaymentResponse = Medoro.Models.PaymentResponse;

namespace Medoro.Services
{
    public class EcomService : IMedoroEcomService
    {
        private readonly int _keyIndex;
        private readonly int _merchantId;
        private readonly string _merchantPrivateKeyPath;
        private readonly string _gatewayKeyPath;
        private readonly bool _isTestEnv;

        private string Endpoint =>
            _isTestEnv ? "https://demo.ipsp.lv/api/v2/soap?wsdl" : "https://ipsp.lv/api/v2/soap?wsdl";

        private readonly Signature _signature;
        private readonly EcomClient _ecomClient;
        private readonly Crypto _crypto;

        public EcomService(
            int keyIndex,
            int merchantId,
            string merchantPrivateKeyPath,
            string merchantPublicKeyPath,
            string gatewayKeyPath,
            bool isTestEnv,
            TimeSpan timeoutConnection)

        {
            _isTestEnv = isTestEnv;
            _crypto = new Crypto();
            _ecomClient = new EcomClient(Endpoint, timeoutConnection);

            _signature = new Signature(merchantPublicKeyPath, merchantPrivateKeyPath);
            _keyIndex = keyIndex;
            _merchantId = merchantId;
            _merchantPrivateKeyPath = merchantPrivateKeyPath;
            _gatewayKeyPath = gatewayKeyPath;
        }

        public async Task<PaymentResponse> PaymentMode6(
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
        )
        {
            var paymentData = EcomFactory.CreatePaymentData(
                isAutoDeposit, 6, descriptor, orderId, amount, currency, orderDescription, card, payerName,
                payerAddress, payerCity, payerCountry, payerZip, payerPhone, payerEmail, notification, frequency,
                endDate);

            var xmlData =  XmlPreparer.Serialize(paymentData);

            var (encryptedRc4OneTimeKeyByGatewayPem,
                encryptedPaymentDataByRc4OneTimeKey,
                signature) = await CryptData(xmlData);

            var result = await _ecomClient.PaymentAsync(new ecomPaymentType()
            {
                KEY = encryptedRc4OneTimeKeyByGatewayPem,
                DATA =  encryptedPaymentDataByRc4OneTimeKey,
                KEY_INDEX = _keyIndex.ToString(),
                INTERFACE = _merchantId.ToString(),
                SIGNATURE = signature,
            });

            var verify = _signature.Verify(xmlData, signature);
            if (!verify)
                throw new MedoroException("Signature validation failed");

            var responseData =  DecryptData(result.PaymentResponse1.DATA, result.PaymentResponse1.KEY);

            return XmlPreparer.Deserialize<PaymentResponse>(responseData);
        }


        public async Task<PaymentResponse> AuthorizePayment(string paymentId, string paRes)
        {
            var authorizeRequest = new AuthenticateData(paymentId, paRes);
            
            var xmlData =  XmlPreparer.Serialize(authorizeRequest);

            var (encryptedRc4OneTimeKeyByGatewayPem,
                encryptedPaymentDataByRc4OneTimeKey,
                signature) = await CryptData(xmlData);

            var result = await _ecomClient.AuthenticateAsync(new ecomPaymentType()
            {
                KEY = encryptedRc4OneTimeKeyByGatewayPem,
                DATA =  encryptedPaymentDataByRc4OneTimeKey,
                KEY_INDEX = _keyIndex.ToString(),
                INTERFACE = _merchantId.ToString(),
                SIGNATURE = signature,
            });

            var verify = _signature.Verify(xmlData, signature);
            if (!verify)
                throw new MedoroException("Signature validation failed");

            var responseData = DecryptData(result.AuthenticateResponse1.DATA, result.AuthenticateResponse1.KEY);

            return XmlPreparer.Deserialize<PaymentResponse>(responseData);
        }

        
       

        private string DecryptData(string encryptedData, string encryptedRc4GatewayKey)
        {
            var keyEncryptedBytes = Convert.FromBase64String(encryptedRc4GatewayKey);
            var rc4Key = _crypto.DecryptRsa(_merchantPrivateKeyPath, keyEncryptedBytes);
            var responseDecryptedData = _crypto.DecryptRc4(rc4Key, Convert.FromBase64String(encryptedData));
            return Encoding.UTF8.GetString(responseDecryptedData);
        }


        private async Task<(string base64EncryptedRc4OneTimeKey, string encryptData, string signature)>
            CryptData(string dataXml)
        {
            var gatewayPemLines = (await File.ReadAllLinesAsync(_gatewayKeyPath)).ToList();
            gatewayPemLines.RemoveAt(0);
            gatewayPemLines.RemoveAt(gatewayPemLines.Count - 1);
            var gatewayBase64 = gatewayPemLines.Aggregate((a, b) => a + b);

            var base64EncryptedRc4OneTimeKey =
                Convert.ToBase64String(_crypto.EncryptRsa(
                        Convert.FromBase64String(gatewayBase64), _crypto.Key
                    )
                );

            var encryptData = Convert.ToBase64String(_crypto.EncryptRc4(dataXml));

            var signature = Convert.ToBase64String(_signature.Sign(Encoding.UTF8.GetBytes(dataXml)));

            return (base64EncryptedRc4OneTimeKey, encryptData, signature);
        }
    }
}