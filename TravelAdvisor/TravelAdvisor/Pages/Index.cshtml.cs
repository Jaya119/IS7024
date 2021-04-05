
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




        public readonly string[] StatesList = { "Iowa", "Illinois", "Indiana", "Kansas", "Michigan", "Minnesota", "Missouri", "North Dakota", "Nebraska", "Ohio", "South Dakota", "Wisconsin", "Connecticut", "Delaware", "Massachusetts", "Maryland", "Maine", "New Hampshire", "New Jersey", "New York", "Pennsylvania", "Rhode Island", "Virginia", "Vermont", "West Virgina", "Arizona", "Colorado", "New Mexico" };



        public void OnGet()
        {

            IsSearchCity = false;
        }

        public void OnPost()
        {
            string city = BreweryCity;

            Url = "https://api.openbrewerydb.org/breweries?by_city=" + city;


            using (var webClient = new WebClient())
            {
                string CityString = webClient.DownloadString(Url);
                Welcome[] welcome = Welcome.FromJson(CityString);
                ViewData["Welcome"] = welcome;
            }

            IsSearchCity = true;

        }
    }
}
