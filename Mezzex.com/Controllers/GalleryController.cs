using Microsoft.AspNetCore.Mvc;

namespace Mezzex.com.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IConfiguration _config;
        public GalleryController(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        public IActionResult Index()
        {
            ViewData["Title"] = _config["SEO:Gallery:Title"];
            ViewData["Description"] = _config["SEO:Gallery:Description"];
            ViewData["Keywords"] = _config["SEO:Gallery:Keywords"];
            return View();
        }


    }
}
