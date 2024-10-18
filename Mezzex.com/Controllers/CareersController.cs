    using Microsoft.AspNetCore.Mvc;
    using Mezzex.com.Services;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    namespace Mezzex.com.Controllers
    {
        public class CareersController : Controller
        {
            private readonly IConfiguration _config;
            private readonly IEmailService _emailService;

            public CareersController(IConfiguration config, IEmailService emailService)
            {
                _config = config;
                _emailService = emailService;
            }

            public IActionResult Index()
            {
                ViewData["Title"] = _config["SEO:Careers:Title"];
                ViewData["Description"] = _config["SEO:Careers:Description"];
                ViewData["Keywords"] = _config["SEO:Careers:Keywords"];
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> SubmitJobApplication(
                string fullName,
                string email,
                string phone,
                string jobTitle,
                string zipcode,
                string currentCTC,
                string city,
                string state,
                string currentEmployment,
                string currentInHandSalary,
                string noticePeriod,
                string referredBy,
                string others,
                IFormFile resumeFile)
            {
                // Validate the file upload
                if (resumeFile != null && resumeFile.Length > 0)
                {
                    // Build the email content for HR
                    string subject = $"Job Application Query : {jobTitle} from {fullName}";
                    string messageBody = $@"
                        <p><strong>Job Title:</strong> {jobTitle}</p>
                        <p><strong>Full Name:</strong> {fullName}</p>
                        <p><strong>Email:</strong> {email}</p>
                        <p><strong>Phone:</strong> {phone}</p>
                        <p><strong>Zipcode:</strong> {zipcode}</p>
                        <p><strong>City:</strong> {city}, <strong>State:</strong> {state}</p>
                        <p><strong>Current CTC:</strong> {currentCTC}</p>
                        <p><strong>In-Hand Salary:</strong> {currentInHandSalary}</p>
                        <p><strong>Current Employment:</strong> {currentEmployment}</p>
                        <p><strong>Notice Period:</strong> {noticePeriod}</p>
                        <p><strong>Referred By:</strong> {referredBy}</p>
                        <p><strong>Additional Information:</strong> {others}</p>";

                    // Send email to HR team with resume attached
                    await _emailService.SendEmailAsync("info@mezzex.com", subject, messageBody, resumeFile);

                    // Send acknowledgment email to the applicant
                    string applicantMessage = $"Thank you {fullName} for applying for the {jobTitle} position at Mezzex. We will review your application and get back to you soon.";
                    await _emailService.SendEmailAsync(email, "Job Application Received", applicantMessage);

                    // Redirect to a Thank You page
                    return RedirectToAction("ThankYou");
                }

                // If no resume is uploaded, return an error message
                ModelState.AddModelError(string.Empty, "Please upload your resume.");
                return View("Index"); // Redirect to the main careers page if validation fails
            }

            public IActionResult ThankYou()
            {
                return View();
            }
        }
    }
