using System;
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

        public bool isSearchCity { get; set; }

        public string Url { get; set; }


        public void OnGet()
        {
            using (var webClient = new WebClient())
            {
                string stateSearch = webClient.DownloadString("https://worldpopulationreview.com/static/states/abbr-name-list.json");

                var state = State.FromJson(stateSearch);
                ViewData["State"] = state;

            }
            isSearchCity = false;
        }
       
        public void OnPost()
        {
            string city = BreweryCity;

            Url = "https://api.openbrewerydb.org/breweries?by_city=" + city;


            using (var webClient = new WebClient())
            {
                string brewery = webClient.DownloadString(Url);
                Welcome[] welcome = Welcome.FromJson(brewery);
                ViewData["Welcome"] = welcome;
            }

            isSearchCity = true;

        }

}   }
