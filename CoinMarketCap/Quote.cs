using Newtonsoft.Json;

namespace CryptoCharter.CoinMarketCap
{
    public class Quote
    {
        public double Price { get;set;}
        [JsonProperty("market_cap")]
        public double MarketCap { get;set;}
    }
}
