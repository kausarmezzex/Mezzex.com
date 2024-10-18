using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Mezzex.com.Controllers
{
    public class BlogController : Controller
    {
        private readonly IConfiguration _config;

        public BlogController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = _config["SEO:Blog:Title"];
            ViewData["Description"] = _config["SEO:Blog:Description"];
            ViewData["Keywords"] = _config["SEO:Blog:Keywords"];
            return View();
        }

        public IActionResult BlogDetails()
        {
            // Customize SEO for individual blog details pages if needed
            return View();
        }
    }
}
