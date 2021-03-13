using System;

namespace Medoro.Services.CryptoServices
{
    internal class StringRandomizer
    {
        public static byte[] RandomRcKey(int length)
        {
            var rnd = new Random();
            var b = new byte[length];
            rnd.NextBytes(b);
            return b;
        }
    }
}