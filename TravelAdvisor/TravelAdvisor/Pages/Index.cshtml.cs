using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TravelAdvisor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (var webClient = new WebClient())
                {
               
string jsonString = webClient.DownloadString("https://worldpopulationreview.com/static/states/abbr-name-list.json");
                var welcome = Welcome.FromJson(jsonString);
                ViewData["Welcome"]= welcome;
        }
    }
}
    }
