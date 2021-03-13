using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace Medoro.Services.CryptoServices
{
    internal class Signature
    {
        private readonly string _privateKeyPath;
        private readonly string _publicKeyPath;

        public Signature(string publicKeyPath, string privateKeyPath)
        {
            _publicKeyPath = publicKeyPath;
            _privateKeyPath = privateKeyPath;
        }

        public byte[] Sign(byte[] data)
        {
            var privateRsa = RsaProviderFromPrivateKeyInPemFile(_privateKeyPath);

            var signedData = privateRsa.SignData(data, CryptoConfig.MapNameToOID("SHA1"));

            return signedData;
        }

        public bool Verify(string message, string signedData)
        {
            var publicRsa = RsaProviderFromPublicKeyInPemFile(_publicKeyPath);

            var verifiedData = publicRsa.VerifyData(Encoding.UTF8.GetBytes(message), CryptoConfig.MapNameToOID("SHA1"),
                Convert.FromBase64String(signedData));

            return verifiedData;
        }

        private RSACryptoServiceProvider RsaProviderFromPrivateKeyInPemFile(string privateKeyPath)
        {
            using (TextReader privateKeyTextReader = new StringReader(File.ReadAllText(privateKeyPath)))
            {
                var pr = new PemReader(privateKeyTextReader);
                var keyPair = (AsymmetricCipherKeyPair) pr.ReadObject();
                var rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters) keyPair.Private);

                var csp = new RSACryptoServiceProvider();
                csp.ImportParameters(rsaParams);
                return csp;
            }
        }

        private RSACryptoServiceProvider RsaProviderFromPublicKeyInPemFile(string publicKeyPath)
        {
            using (TextReader privateKeyTextReader = new StringReader(File.ReadAllText(publicKeyPath)))
            {
                var pr = new PemReader(privateKeyTextReader);
                var publicKey = (AsymmetricKeyParameter) pr.ReadObject();
                var rsaParams = DotNetUtilities.ToRSAParameters((RsaKeyParameters) publicKey);

                var csp = new RSACryptoServiceProvider();
                csp.ImportParameters(rsaParams);
                return csp;
            }
        }
    }
}