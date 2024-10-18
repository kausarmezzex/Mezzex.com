using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Mezzex.com.Controllers
{
    public class AboutController : Controller
    {
        private readonly IConfiguration _config;

        public AboutController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = _config["SEO:About:Title"];
            ViewData["Description"] = _config["SEO:About:Description"];
            ViewData["Keywords"] = _config["SEO:About:Keywords"];
            return View("about-us");
        }
    }
}
