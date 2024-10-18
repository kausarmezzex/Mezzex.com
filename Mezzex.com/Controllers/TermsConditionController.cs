using Microsoft.AspNetCore.Mvc;

namespace Mezzex.com.Controllers
{
    public class TermsConditionController : Controller
    {
        private readonly IConfiguration _config;

        public TermsConditionController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = _config["SEO:TermsCondition:Title"];
            ViewData["Description"] = _config["SEO:TermsCondition:Description"];
            ViewData["Keywords"] = _config["SEO:TermsCondition:Keywords"];
            return View();
        }
    }
}
