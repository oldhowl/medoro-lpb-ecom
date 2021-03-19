using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Medoro.Services.MedoroClients
{
    public class MedoroHttpClient
    {
        private bool _isTestEnv;

        public MedoroHttpClient(bool isTestEnv)
        {
            _isTestEnv = isTestEnv;
        }

        private string PaymentEndpoint => _isTestEnv ? "https://demo.ipsp.lv/form/v2/" : "https://ipsp.lv/form/v2/";

        public async Task Post(string key, string data, int keyIndex, int merchantId, string signature,
            string callback, string errorCallback)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("INTERFACE", merchantId.ToString()),
                new KeyValuePair<string, string>("KEY_INDEX", keyIndex.ToString()),
                new KeyValuePair<string, string>("KEY", key),
                new KeyValuePair<string, string>("DATA", data),
                new KeyValuePair<string, string>("SIGNATURE", signature),
                new KeyValuePair<string, string>("CALLBACK", callback),
                new KeyValuePair<string, string>("ERROR_CALLBACK", errorCallback),
            });

            using var httpClient = new HttpClient();
            var result = await httpClient.PostAsync(PaymentEndpoint, formContent);

            result.EnsureSuccessStatusCode();

            var response = await result.Content.ReadAsStringAsync();
        }
    }
}