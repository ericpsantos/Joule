using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Joule.Repositories
{
    public class SendGridService
    {
        public void SendWelcomeEmail(string email)
        {
            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage();

            // Add the message properties.
            myMessage.From = new MailAddress("noreply@joule.com", "Projeto Joule");

            // Add multiple addresses to the To field.
            List<string> recipients = new List<string>
            {
                email
            };

            myMessage.AddTo(recipients);
            myMessage.AddBcc(@"cadastro@projetojoule.com");
            myMessage.AddBcc(@"ericsantos@outlook.com");

            myMessage.Subject = "Bem-Vindo ao Projeto Joule!";

            //Add the HTML and Text bodies
            //myMessage.Html = "<p>Hello World!</p>";
            myMessage.Text = "Seja bem-vindo!";

            // Create network credentials to access your SendGrid account
            //var username = "your_sendgrid_username";
            //var pswd = "your_sendgrid_password";

            var username = System.Environment.GetEnvironmentVariable("SENDGRID_USER"); 
            var pswd = System.Environment.GetEnvironmentVariable("SENDGRID_PASS");

            if(username == null || pswd == null)
            {
                throw new Exception("No Email Credentials Found");
            }

            var credentials = new NetworkCredential(username, pswd);

            // Create an Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            // You can also use the **DeliverAsync** method, which returns an awaitable task.
            transportWeb.DeliverAsync(myMessage);
        }

        public void SendVoluntarioWelcomeEmail(string email)
        {
            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage();

            // Add the message properties.
            myMessage.From = new MailAddress("noreply@joule.com", "Projeto Joule");

            // Add multiple addresses to the To field.
            List<string> recipients = new List<string>
            {
                email
            };

            myMessage.AddTo(recipients);
            myMessage.AddBcc(@"cadastro@projetojoule.com");

            myMessage.Subject = "Bem-Vindo ao Projeto Joule!";

            //Add the HTML and Text bodies
            //myMessage.Html = "<p>Hello World!</p>";
            myMessage.Text = "Seja bem-vindo!";

            // Create network credentials to access your SendGrid account
            //var username = "your_sendgrid_username";
            //var pswd = "your_sendgrid_password";

            var username = System.Environment.GetEnvironmentVariable("SENDGRID_USER");
            var pswd = System.Environment.GetEnvironmentVariable("SENDGRID_PASS");

            if (username == null || pswd == null)
            {
                throw new Exception("No Email Credentials Found");
            }

            var credentials = new NetworkCredential(username, pswd);

            // Create an Web transport for sending email.
            var transportWeb = new Web(credentials);

            // Send the email.
            // You can also use the **DeliverAsync** method, which returns an awaitable task.
            transportWeb.DeliverAsync(myMessage);
        }
    }
}