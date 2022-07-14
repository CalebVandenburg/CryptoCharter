namespace CryptoCharter.Graph
{
    public class GraphData
    {
        public string XLabel { get; set; }
        public string YLabel { get; set; }
        public List<string> Labels { get; set; }
        public List<GraphDataPoint> GraphDataPoints { get; set; }
    }
    public class GraphDataPoint
    {
        public List<double> Data { get;set; }
    }
}
