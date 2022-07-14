using CryptoCharter.CoinMarketCap;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoCharter.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private CMCManager CMCManager;

        public IndexModel(ILogger<IndexModel> logger, CMCManager cmcManager)
        {
            _logger = logger;
            CMCManager = cmcManager;
        }

        public void OnGet()
        {

        }
    }
}