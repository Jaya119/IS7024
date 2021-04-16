using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickType;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Weather;

namespace TravelAdvisor.Pages
{
    public class WeatherModel : PageModel
    {

        public double LongitudeId { get; set; }

        public double LatitudeId {get; set; }

        public string Date { get; set; }

        public new string Url { get; set; }

        public bool IsSearchTimings { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
        double latitude = 23.5;
        double longitude = 45.6;
        string date = Date; 
            Url = "https://api.sunrise-sunset.org/json?lat=" + latitude + "&lng=" + longitude + "date=" + date;
            using (var webClient = new WebClient())
            {
                string timings = webClient.DownloadString(Url);
                HighFive welcome = HighFive.FromJson(timings);
                ViewData["Weather"] = welcome;

            }
            IsSearchTimings = true;
        }
    }
}
