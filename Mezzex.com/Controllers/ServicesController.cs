using Microsoft.AspNetCore.Mvc;

namespace Mezzex.com.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IConfiguration _config;

        public ServicesController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Website_designing_development()
        {
            ViewData["Title"] = _config["SEO:Services:WebsiteDesigningDevelopment:Title"];
            ViewData["Description"] = _config["SEO:Services:WebsiteDesigningDevelopment:Description"];
            ViewData["Keywords"] = _config["SEO:Services:WebsiteDesigningDevelopment:Keywords"];
            return View();
        }

        public IActionResult Digital_marketing()
        {
            ViewData["Title"] = _config["SEO:Services:DigitalMarketing:Title"];
            ViewData["Description"] = _config["SEO:Services:DigitalMarketing:Description"];
            ViewData["Keywords"] = _config["SEO:Services:DigitalMarketing:Keywords"];
            return View();
        }

        public IActionResult Software_development()
        {
            ViewData["Title"] = _config["SEO:Services:SoftwareDevelopment:Title"];
            ViewData["Description"] = _config["SEO:Services:SoftwareDevelopment:Description"];
            ViewData["Keywords"] = _config["SEO:Services:SoftwareDevelopment:Keywords"];
            return View();
        }

        public IActionResult App_development()
        {
            ViewData["Title"] = _config["SEO:Services:AppDevelopment:Title"];
            ViewData["Description"] = _config["SEO:Services:AppDevelopment:Description"];
            ViewData["Keywords"] = _config["SEO:Services:AppDevelopment:Keywords"];
            return View();
        }

        public IActionResult Ecommerce_service()
        {
            ViewData["Title"] = _config["SEO:Services:EcommerceService:Title"];
            ViewData["Description"] = _config["SEO:Services:EcommerceService:Description"];
            ViewData["Keywords"] = _config["SEO:Services:EcommerceService:Keywords"];
            return View();
        }

        public IActionResult Warehouse_management()
        {
            ViewData["Title"] = _config["SEO:Services:WarehouseManagement:Title"];
            ViewData["Description"] = _config["SEO:Services:WarehouseManagement:Description"];
            ViewData["Keywords"] = _config["SEO:Services:WarehouseManagement:Keywords"];
            return View();
        }
    }
}
