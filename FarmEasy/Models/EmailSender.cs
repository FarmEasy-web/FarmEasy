using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FarmEasy.Models
{
    public class EmailSender : IEmailSender
    {
        public string host;
        public int port;
        public bool enableSSL;
        public string userName;
        public string password;

        public EmailSender()
        {
            host = "smtp.live.com";
            port = 587;
            enableSSL = true;
            userName = "n_gondaliya@live.com";
            password = "nikhil1212";
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            NetworkCredential networkCredentials = new NetworkCredential(userName,password);
            var client = new SmtpClient(host, port)
            {
                EnableSsl = enableSSL,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };
            client.Credentials = networkCredentials;
            return client.SendMailAsync(
                new MailMessage(userName, email, subject, htmlMessage) {IsBodyHtml=true });
        }
    }
}
