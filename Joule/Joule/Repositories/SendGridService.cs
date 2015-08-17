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

            this.SendEmail(myMessage);
            this.SendAdminEmail(usuario);
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

            myMessage.Subject = "Bem-Vindo ao Projeto Joule!";

            //Add the HTML and Text bodies
            //myMessage.Html = "<p>Hello World!</p>";
            myMessage.Html = string.Format(@"<img src='http://projetojoule.com/wp-content/uploads/LogoNome.png' />
            <p>Olá {0},</p>
            <br />
            <p>Muito obrigado por ter preenchido seu cadastro e pelo seu interesse em nos ajudar como voluntário. 
            Seja bem-vindo ao time do Projeto Joule, em breve entraremos em contato!</p>
            <br />
            <p>Por enquanto, não deixe de curtir nossa página e nos seguir nas redes sociais:</p>
            <br />
            <p>Linkedin: <a href='https://www.linkedin.com/company/projeto-joule'>https://www.linkedin.com/company/projeto-joule</a> <br />

            Facebook: <a href='https://www.facebook.com/projetojoule'>https://www.facebook.com/projetojoule</a> <br />

            Twitter: <a href='https://twitter.com/projetojoule'>https://twitter.com/projetojoule</a> <br />

            Blog: <a href='http://www.projetojoule.com/blog'>http://www.projetojoule.com/blog</a></p>
            <br />
            <p>Um abraço,</p>
            <br />
            <p>Equipe Projeto Joule<p>", voluntario.FirstName);

            this.SendEmail(myMessage);
            this.SendAdminEmail(voluntario);
        }

        public void SendAdminEmail(Voluntario voluntario)
        {
            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage();

            // Add the message properties.
            myMessage.From = new MailAddress("noreply@joule.com", "Projeto Joule");

            // Add multiple addresses to the To field.
            List<string> recipients = new List<string>
            {
                @"cadastro@projetojoule.com"
            };

            myMessage.AddTo(recipients);

            myMessage.Subject = "Novo Voluntário!";

            myMessage.Html += string.Format(@"<table>
            <tr><th>Nome</th><th>Sobrenome</th><th>Email</th>
            <th>Telefone</th><th>Endereço</th><th>Cidade</th>
            <th>Estado</th><th>País</th><th>Programas</th>
            <th>Anos de Experiência</th><th>Empres</th><th>Cargo</th>
            <th>Empresas Passadas</th><th>Segmentos</th><th>Áreas</th>
            <th>Escolaridade</th><th>LinkedIn</th></tr>
            <tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>
            <td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td>
            <td>{9}</td><td>{10}</td><td>{11}</td><td>{12}</td><td>{13}</td>
            <td>{14}</td><td>{15}</td><td>{16}</td></tr></table>", voluntario.FirstName, voluntario.LastName, voluntario.Email,
            voluntario.PhoneNumber, voluntario.Address, voluntario.City,
            voluntario.State, voluntario.Country, string.Join(",", voluntario.Programs.ToArray()),
            voluntario.YearsOfExperience, voluntario.CurrentEmployer, voluntario.CurrentPosition,
            voluntario.PastEmployers, string.Join(",", voluntario.WorkSegments.ToArray()), string.Join(",", voluntario.WorkAreas.ToArray()), voluntario.Degree, voluntario.LinkedInProfile);

            this.SendEmail(myMessage);
        }

        public void SendAdminEmail(Usuario usuario)
        {
            // Create the email object first, then add the properties.
            var myMessage = new SendGridMessage();

            // Add the message properties.
            myMessage.From = new MailAddress("noreply@joule.com", "Projeto Joule");

            // Add multiple addresses to the To field.
            List<string> recipients = new List<string>
            {
                @"cadastro@projetojoule.com"
            };

            myMessage.AddTo(recipients);

            myMessage.Subject = "Novo Usuário!";

            myMessage.Html += string.Format(@"<table>
            <tr><th>Nome</th><th>Sobrenome</th><th>Email</th>
            <th>Telefone</th><th>Endereço</th><th>Cidade</th>
            <th>Estado</th><th>País</th><th>Programas</th>
            <th>Profile</th><th>Sobre</th></tr>
            <tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>
            <td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td>
            <td>{9}</td><td>{10}</td></tr></table>", usuario.FirstName, usuario.LastName, usuario.Email,
            usuario.PhoneNumber, usuario.Address, usuario.City,
            usuario.State, usuario.Country, string.Join(",", usuario.Programs.ToArray()),
            usuario.CurrentProfile, usuario.About);

            this.SendEmail(myMessage);
        }

        private void SendEmail(SendGridMessage myMessage)
        {
            // Create network credentials to access your SendGrid account
            //var username = "azure_ba4de69f131861e607d1ca878a4a2312@azure.com";
            //var pswd = "02uchtdorf";

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