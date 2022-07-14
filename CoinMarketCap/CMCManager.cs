using CryptoCharter.Graph;
using Newtonsoft.Json;
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
        public LatestQuotes GetLatestQuotes()
        {
            string urlParameters = "?symbol=BTC,ETH";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri($"{BaseURL}/quotes/latest");
            client.DefaultRequestHeaders.Add("Accepts", "application/json");
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", APIKey);
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            LatestQuotes latestQuotes = JsonConvert.DeserializeObject<LatestQuotes>(data);
            GraphData graphData = new GraphData() { 
                 XLabel = "Interval",
                 YLabel = "Price",
                  Labels = new List<string>() { "IntervalValue" },
                  GraphDataPoints = new List<GraphDataPoint>()
            };

            GraphDataPoint graphDataPoint = new GraphDataPoint()
            {
                Data = new List<double>()
            };
            foreach (var quote in latestQuotes.Data)
            {
                graphData.Labels.Add(quote.Key);
                graphDataPoint.Data.Add(quote.Value.Quote["USD"].Price);
            }
            graphData.GraphDataPoints.Add(graphDataPoint);
            latestQuotes.GraphData = graphData;
            return latestQuotes;
        }
    }
}
