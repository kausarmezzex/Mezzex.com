using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Mezzex.com.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mezzex.com.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = _config["SEO:Home:Title"];
            ViewData["Description"] = _config["SEO:Home:Description"];
            ViewData["Keywords"] = _config["SEO:Home:Keywords"];

            var model = new ServiceModel
            {
                Services = new List<SelectListItem>
                {
                    new SelectListItem { Value = "Website Designing & Development", Text = "Website Designing & Development" },
                    new SelectListItem { Value = "App Development", Text = "App Development" },
                    new SelectListItem { Value = "Software Development", Text = "Software Development" },
                    new SelectListItem { Value = "Ecommerce Service", Text = "Ecommerce Service" },
                    new SelectListItem { Value = "Digital Marketing", Text = "Digital Marketing" },
                    new SelectListItem { Value = "Warehouse Management", Text = "Warehouse Management" },
                    new SelectListItem { Value = "other", Text = "Other" }
                }
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy Policy";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            ViewData["Title"] = "Error";
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
