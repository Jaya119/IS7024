using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickType;

namespace TravelAdvisor.Pages
{
    public class DataIntegrationModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString("https://worldpopulationreview.com/static/states/abbr-name-list.json");
               
                var state = State.FromJson(jsonString);
                ViewData["State"] = state;
                
            }

        }
    }
}
