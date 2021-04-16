using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelAdvisor.Pages
{
    public class LaurateModel : PageModel
    {
        public bool IsSearchTimings { get; set; }

        public LaurateModel(bool isSearchTimings)
        {
            IsSearchTimings = isSearchTimings;
        }
        public void OnGet()
        {
        }
    }
}
