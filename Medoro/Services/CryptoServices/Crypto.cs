using System.IO;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using PemUtils;

namespace Medoro.Services.CryptoServices
{
    internal class Crypto
    {
        public byte[] Key { get; }

        public Crypto()
        {
            Key = StringRandomizer.RandomRcKey(60);
        }

        public byte[] EncryptRc4(string data)
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            return Rc4.Encrypt(Key, bytes);
        }

        public byte[] DecryptRc4(byte[] key, byte[] data)
        {
            return Rc4.Decrypt(key, data);
        }

        public byte[] EncryptRsa(byte[] pubKey, byte[] data)
        {
            var obj = Asn1Object.FromByteArray(pubKey);
            var publicKeySequence = (DerSequence) obj;

            var encodedPublicKey = (DerBitString) publicKeySequence[1];
            var publicKey = (DerSequence) Asn1Object.FromByteArray(encodedPublicKey.GetBytes());

            var modulus = (DerInteger) publicKey[0];
            var exponent = (DerInteger) publicKey[1];
            var keyParameters = new RsaKeyParameters(false, modulus.PositiveValue, exponent.PositiveValue);
            var parameters = DotNetUtilities.ToRSAParameters(keyParameters);
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(parameters);

            return rsa.Encrypt(data, false);
        }


        public byte[] DecryptRsa(string filePath, byte[] data)
        {
            
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            using (var stream = File.OpenRead(filePath))
            using (var reader = new PemReader(stream))
            {
                var rsaParameters = reader.ReadRsaKey();
                rsa.ImportParameters(rsaParameters);
            }

            return rsa.Decrypt(data, false);
        }
    }
}