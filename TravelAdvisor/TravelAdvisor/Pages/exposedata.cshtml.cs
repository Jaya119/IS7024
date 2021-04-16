using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelAdvisor.Pages
{
    public class exposedataModel : PageModel
    {
        public JsonResult OnGet()
        {

            string url = "https://api.sunrise-sunset.org/json?lat=39.74&lng=-84.51";

            string TimingDetails = getData(url);



            Weather.HighFive array = Weather.HighFive.FromJson(TimingDetails);



            return new JsonResult(array);
        }
        private string getData(string url)
        {
            using( WebClient webClient = new WebClient())
            {
                return webClient.DownloadString(url);
            }
        }
    }
}
