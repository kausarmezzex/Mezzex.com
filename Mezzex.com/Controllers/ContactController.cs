using Microsoft.AspNetCore.Mvc;
using Mezzex.com.Models;
using Mezzex.com.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        // GET: Display Contact Form with Random Math Captcha
        public IActionResult Index()
        {
            var (question, answer) = GenerateMathCaptcha();
            ViewBag.CaptchaQuestion = question; // Display question in the view
            HttpContext.Session.SetString("CaptchaAnswer", answer.ToString());  // Store answer in session

            var model = new ServiceModel
            {
                Services = GetServicesList()  // Populate the dropdown
            };
            return View("Contact-us", model);
        }

        // POST: Handle Form Submission with Captcha Validation
        [HttpPost]
        public async Task<IActionResult> SubmitContactForm(ServiceModel model, string captchaAnswer)
        {
            var correctAnswer = HttpContext.Session.GetString("CaptchaAnswer");

            // Validate Captcha
            if (captchaAnswer != correctAnswer)
            {
                ModelState.AddModelError("captchaAnswer", "Captcha validation failed. Please try again.");

                // Repopulate services dropdown and return view with the same model
                model.Services = GetServicesList();
                return View("Contact-us", model);
            }

            // Proceed with sending email if captcha is valid
            string subjectForMain = $"New Contact Query: {model.Subject} from {model.Email}";
            string messageBody = $@"
                <p><strong>Email:</strong> {model.Email}</p>
                <p><strong>Selected Service:</strong> {model.SelectedService}</p>
                <p><strong>Subject:</strong> {model.Subject}</p>
                <p><strong>Phone:</strong> {model.Phone}</p>
                <p><strong>Message:</strong> {model.Message}</p>";

            await _emailService.SendEmailAsync(_config["EmailSettings:SenderEmail"], subjectForMain, messageBody);
            await _emailService.SendEmailAsync(model.Email, "Thank you for contacting Mezzex",
                "We have received your query and will get back to you shortly.");

            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        // Helper: Generate a Random Math Captcha
        private (string, int) GenerateMathCaptcha()
        {
            var random = new Random();
            int num1 = random.Next(1, 10);  // First random number between 1 and 9
            int num2 = random.Next(1, 10);  // Second random number between 1 and 9
            int operation = random.Next(1, 4);  // Randomly choose between addition, subtraction, multiplication

            string question;
            int answer;

            switch (operation)
            {
                case 1:
                    question = $"{num1} + {num2} = ?";
                    answer = num1 + num2;
                    break;
                case 2:
                    question = $"{num1} - {num2} = ?";
                    answer = num1 - num2;
                    break;
                case 3:
                    question = $"{num1} × {num2} = ?";
                    answer = num1 * num2;
                    break;
                default:
                    question = $"{num1} + {num2} = ?";
                    answer = num1 + num2;
                    break;
            }

            return (question, answer);
        }

        // Helper: Get List of Services for Dropdown
        private List<SelectListItem> GetServicesList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Website Designing & Development", Text = "Website Designing & Development" },
                new SelectListItem { Value = "App Development", Text = "App Development" },
                new SelectListItem { Value = "Software Development", Text = "Software Development" },
                new SelectListItem { Value = "Ecommerce Service", Text = "Ecommerce Service" },
                new SelectListItem { Value = "Digital Marketing", Text = "Digital Marketing" },
                new SelectListItem { Value = "Warehouse Management", Text = "Warehouse Management" },
                new SelectListItem { Value = "other", Text = "Other" }
            };
        }
    }
}
