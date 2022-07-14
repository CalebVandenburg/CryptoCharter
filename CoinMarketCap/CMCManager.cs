using System.Net.Http.Headers;

namespace CryptoCharter.CoinMarketCap
{
    public class CMCManager
    {
        private string APIKey;
        private string BaseURL;
        public CMCManager(string apikey, string baseURL)
        {
            this.APIKey = apikey;
            this.BaseURL = baseURL;
        }
        public void GetLatest()
        {
            string urlParameters = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{BaseURL}/listings/latest");
            client.DefaultRequestHeaders.Add("Accepts", "application/json");
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", APIKey);
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            var data = response.Content.ReadAsStringAsync().Result;
        }
    }
}
