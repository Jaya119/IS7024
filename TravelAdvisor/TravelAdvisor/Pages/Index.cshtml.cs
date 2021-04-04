
﻿using System;
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickType;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;




namespace TravelAdvisor.Pages

{ 
  
    public class IndexModel : PageModel
    {

        public object BreweryAPI { get; private set; }
        [BindProperty]
        public string BreweryType { get; set; }
        [BindProperty]
        public string BreweryCity { get; set; }

        public bool IsSearchCity { get; set; }

        public new string Url { get; set; }

        public bool IsCityNull { get; set; }
        public void OnGet()
        {

            IsSearchCity = false;
        }

        public void OnPost()
        {
            string city = BreweryCity;
            // Check whether city populated on screen
            IsCityNull = string.IsNullOrEmpty(city);
            // Fetch data from API only when city populated
            if (!IsCityNull)
            {
                Url = "https://api.openbrewerydb.org/breweries?by_city=" + city;

                using (var webClient = new WebClient())
                {
                    string jsonString = webClient.DownloadString(Url);
                    Welcome[] welcome = Welcome.FromJson(jsonString);
                    ViewData["Welcome"] = welcome;
                }

                IsSearchCity = true;
            }
        }
    }
}
