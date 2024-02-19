using System.Globalization;
using System.Net.Mail;

namespace Unicamente.Application.ExternalServices.Email
{
    public class Email
    {

        public static void EmailAtivacaoConta(string nome, string email, string link)
        {
            TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;
            string html = Modelos.AtivacaoConta();
            html = html
                  .Replace("@nome", textInfo.ToTitleCase(nome.ToLower().Trim()))
                  .Replace("@link", link);

            EnviarEmail(email, html);
        }

        public static void EmailContato(string nome, string email, string telefone, string assunto, string mensagem)
        {
            TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;
            string html = Modelos.ContatoEmail();
            html = html
                  .Replace("@nome", textInfo.ToTitleCase(nome.ToLower().Trim()))
                  .Replace("@email", email)
                  .Replace("@telefone", string.IsNullOrEmpty(telefone) ? "" : telefone)
                  .Replace("@assunto", assunto)
                  .Replace("@mensagem", mensagem);

            EnviarEmail(html);
        }


        private static void EnviarEmail(string email, string texto)
        {
            //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpClient SmtpServer = new SmtpClient("smtp.titan.email");
            var mail = new MailMessage();
            mail.From = new MailAddress("contato@oskem.com.br");
            mail.To.Add(email);
            //mail.To.Add("jackson_jb007@hotmail.com");
            mail.Subject = "Oskem Multipropriedades";
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = texto;//"<h1>Esse é um codigo HTML</h1> <b>percebe-se que as tags funcionam</b>";
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("lanchonete.nsjb@gmail.com", "jszalbddctcqzaqf");
            SmtpServer.Credentials = new System.Net.NetworkCredential("contato@oskem.com.br", "oskembr123");
            SmtpServer.EnableSsl = true;

            try
            {
                SmtpServer.Send(mail);
            }
            catch (System.Exception erro)
            {
                //trata erro
            }
            finally
            {
                mail = null;
            }
        }

        private static void EnviarEmail(string texto)
        {
            //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpClient SmtpServer = new SmtpClient("smtp.titan.email");
            var mail = new MailMessage();
            mail.From = new MailAddress("contato@oskem.com.br");
            mail.To.Add("daniel@oskem.com.br");
            mail.To.Add("mirian@oskem.com.br");

            mail.Bcc.Add("jackson_jb007@hotmail.com");
            mail.Bcc.Add("mfbelem@gmail.com");

            //mail.To.Add(email);
            //mail.To.Add(email);
            //mail.To.Add("jackson_jb007@hotmail.com");
            mail.Subject = "Oskem Multipropriedades - Novo Contato";
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = texto;//"<h1>Esse é um codigo HTML</h1> <b>percebe-se que as tags funcionam</b>";
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("lanchonete.nsjb@gmail.com", "jszalbddctcqzaqf");
            SmtpServer.Credentials = new System.Net.NetworkCredential("contato@oskem.com.br", "oskembr123");
            SmtpServer.EnableSsl = true;

            try
            {
                SmtpServer.Send(mail);
            }
            catch (System.Exception erro)
            {
                //trata erro
            }
            finally
            {
                mail = null;
            }
        }

    }
}
