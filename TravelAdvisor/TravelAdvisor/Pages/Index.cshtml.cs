using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
            
            String key = System.IO.File.ReadAllText("CitiesAPIKey.txt");
            String citiesdata = webClient.DownloadString("https://worldpopulationreview.com/static/states/abbr-name-list.json" + key);
            QuickType.Welcome cities = QuickType.Welcome.FromJson(citiesdata);
            long name = 0
            foreach (QuickType.Datum city in cities.Data)
            {

                name = city.name


            }
            if (name < 1)
            {

                ViewData["CityMessage"] = "City doesnt exist";
            }
            else
            {
                viewData["CityMessage"] = "Heres your favorite city!";

            }
        }
    }
}
