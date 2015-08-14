using Joule.Models;
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
        public void SendWelcomeEmail(Usuario usuario)
        {
            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage();

            // Add the message properties.
            myMessage.From = new MailAddress("noreply@joule.com", "Projeto Joule");

            // Add multiple addresses to the To field.
            List<string> recipients = new List<string>
            {
                usuario.Email
            };

            myMessage.AddTo(recipients);
            myMessage.AddBcc(@"cadastro@projetojoule.com");

            myMessage.Subject = "Obrigado!";

            //Add the HTML and Text bodies
            myMessage.Html = string.Format(@"<img src='http://projetojoule.com/wp-content/uploads/LogoNome.png' />
            <p>Olá {0},</p>
            <p>Muito obrigado por ter efetuado sua inscrição para participar nos programs do Projeto Joule. 
            Este e-mail é para confirmar que recebemos sua inscrição e que estamos ansiosos para começar a trabalhar juntos. 
            Em breve entraremos em contato!</p>
            <p>Por enquanto, não deixe de curtir nossa página e nos seguir nas redes sociais:</p>
            <p>Linkedin: <a href='https://www.linkedin.com/company/projeto-joule'>https://www.linkedin.com/company/projeto-joule</a> <br />

            Facebook: <a href='https://www.facebook.com/projetojoule'>https://www.facebook.com/projetojoule</a> <br />

            Twitter: <a href='https://twitter.com/projetojoule'>https://twitter.com/projetojoule</a> <br />

            Blog: <a href='http://www.projetojoule.com/blog'>http://www.projetojoule.com/blog</a></p>

            <p>Um abraço,</p>

            <p>Equipe Projeto Joule<p>", usuario.FirstName);
            //myMessage.Text = "Seja bem-vindo!";

            // Create network credentials to access your SendGrid account
            //var username = "azure_ba4de69f131861e607d1ca878a4a2312@azure.com";
            //var pswd = "";

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

        public void SendVoluntarioWelcomeEmail(Voluntario voluntario)
        {
            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage();

            // Add the message properties.
            myMessage.From = new MailAddress("noreply@joule.com", "Projeto Joule");

            // Add multiple addresses to the To field.
            List<string> recipients = new List<string>
            {
                voluntario.Email
            };

            myMessage.AddTo(recipients);
            myMessage.AddBcc(@"cadastro@projetojoule.com");

            myMessage.Subject = "Bem-Vindo ao Projeto Joule!";

            //Add the HTML and Text bodies
            //myMessage.Html = "<p>Hello World!</p>";
            myMessage.Html = string.Format(@"<img src='http://projetojoule.com/wp-content/uploads/LogoNome.png' />
            <p>Olá {0},</p>
            <p>Muito obrigado por ter preenchido seu cadastro e pelo seu interesse em nos ajudar como voluntário. 
            Seja bem-vindo ao time do Projeto Joule, em breve entraremos em contato!</p>
            <p>Por enquanto, não deixe de curtir nossa página e nos seguir nas redes sociais:</p>
            <p>Linkedin: <a href='https://www.linkedin.com/company/projeto-joule'>https://www.linkedin.com/company/projeto-joule</a> <br />

            Facebook: <a href='https://www.facebook.com/projetojoule'>https://www.facebook.com/projetojoule</a> <br />

            Twitter: <a href='https://twitter.com/projetojoule'>https://twitter.com/projetojoule</a> <br />

            Blog: <a href='http://www.projetojoule.com/blog'>http://www.projetojoule.com/blog</a></p>

            <p>Um abraço,</p>

            <p>Equipe Projeto Joule<p>", voluntario.FirstName);

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