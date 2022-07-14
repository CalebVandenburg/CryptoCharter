using CryptoCharter.Graph;

namespace CryptoCharter.CoinMarketCap
{
    public class LatestQuotes
    {
        public Dictionary<string, LatestQuote> Data { get; set; }
        public GraphData GraphData { get; set; }
    }
    public class LatestQuote
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Slug { get; set; }
        public Dictionary<string, Quote> Quote { get; set; }
    }
}
