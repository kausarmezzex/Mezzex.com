using Microsoft.AspNetCore.Mvc;

namespace Mezzex.com.Controllers
{
    public class FaqController : Controller
    {
        private readonly IConfiguration _config;
        public FaqController(IConfiguration config) {
            _config = config;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = _config["SEO:Faq:Title"];
            ViewData["Description"] = _config["SEO:Faq:Description"];
            ViewData["Keywords"] = _config["SEO:Faq:Keywords"];
            return View();
        }
    }
}
