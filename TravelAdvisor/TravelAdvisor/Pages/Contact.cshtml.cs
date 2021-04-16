using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TravelAdvisor.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        public ContactModel(IWebHostEnvironment _environment)
        {
            environment = _environment;
        }

        [BindProperty]
        public IFormFile Upload { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string fileName = Upload.FileName;
            var file = Path.Combine(environment.ContentRootPath, "upload", fileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                Upload.CopyTo(fileStream);
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(file);
        }
    }
}
