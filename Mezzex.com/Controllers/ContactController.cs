using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Mezzex.com.Models;
using Mezzex.com.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mezzex.com.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;

        public ContactController(IConfiguration config, IEmailService emailService)
        {
            _config = config;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = _config["SEO:Contact:Title"];
            ViewData["Description"] = _config["SEO:Contact:Description"];
            ViewData["Keywords"] = _config["SEO:Contact:Keywords"];

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

            return View("Contact-us", model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContactForm(string email, string selectedService, string subject, string phone, string message)
        {
            // Validate form data (you can add custom validation logic here)
            string subjectForMain = $"New Contact us  Query : {subject} from {email}";
            string messageBody = $@"
                <p><strong>Email:</strong> {email}</p>
                <p><strong>Selected Service:</strong> {selectedService}</p>
                <p><strong>Subject:</strong> {subject}</p>
                <p><strong>Phone:</strong> {phone}</p>
                <p><strong>Message:</strong> {message}</p>";

            // Send email
            await _emailService.SendEmailAsync(_config["EmailSettings:SenderEmail"], subjectForMain, messageBody);

            // Optionally, send an acknowledgment to the user
            await _emailService.SendEmailAsync(email, "Thank you for contacting Mezzex", "We have received your query and will get back to you shortly.");

            // Return a thank you page or redirect
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
