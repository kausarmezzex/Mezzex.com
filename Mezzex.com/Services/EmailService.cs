using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Mezzex.com.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string messageBody, IFormFile attachment = null);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string messageBody, IFormFile attachment = null)
        {
            try
            {
                // Fetch the email settings from the configuration
                string smtpServer = _config["EmailSettings:SmtpServer"];
                string senderEmail = _config["EmailSettings:SenderEmail"];
                string senderPassword = _config["EmailSettings:SenderPassword"];
                int port = int.Parse(_config["EmailSettings:Port"]);
                bool enableSsl = bool.Parse(_config["EmailSettings:EnableSsl"]);

                // Create SMTP client with the correct settings
                var smtpClient = new SmtpClient(smtpServer)
                {
                    Port = port,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = enableSsl
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = subject,
                    Body = messageBody,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                // Attach the file if provided
                if (attachment != null)
                {
                    var memoryStream = new MemoryStream();
                    await attachment.CopyToAsync(memoryStream); // Copy the content to the memory stream
                    memoryStream.Position = 0; // Reset the position to the beginning of the stream

                    var attachmentData = new Attachment(memoryStream, attachment.FileName, attachment.ContentType);
                    mailMessage.Attachments.Add(attachmentData);
                }

                // Send the email
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException smtpEx)
            {
                // Log detailed information about the SMTP exception
                Console.WriteLine($"SMTP Error: {smtpEx.StatusCode} - {smtpEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An error occurred while sending email: {ex.Message}");
                throw;
            }
        }

    }
}
