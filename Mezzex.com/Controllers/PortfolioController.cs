using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mezzex.com.Controllers
{
 
    public class PortfolioController : Controller
    {
        private readonly IConfiguration _config;

        public PortfolioController(IConfiguration config) {
            this._config = config;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = _config["SEO:Portfolio:Title"];
            ViewData["Description"] = _config["SEO:Portfolio:Description"];
            ViewData["Keywords"] = _config["SEO:Portfolio:Keywords"];
            return View();
        }
    }
}
