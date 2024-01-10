using Pastorials.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.Xml;

namespace Pastorials.EmailServiceModels
{
    public class EmailSerivce : IEmailService
    {
        private static readonly Random random = new Random();
        /* private readonly PastoralisContext _context;
         public EmailSerivce(PastoralisContext context)
         {
             _context = context;
         }
 */
        public string GenerateOTP()
        {
            const int otpLength = 6;
            const string chars = "0123456789";

            return new string(Enumerable.Repeat(chars, otpLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public Task SendEmailAsync(string email, string subject , string message, string otp)
        {
            var mail = "samarjeet.khanuja@appsphere.in";
            var pw = "EIgVRtBCH3apswyd";
            var client = new SmtpClient("smtp-relay.brevo.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)

            };
            return client.SendMailAsync(
                new MailMessage(from: mail,
                                 to: email,
                                 subject,
                                 message));

        }
        

    }
}
