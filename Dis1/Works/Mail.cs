using System.Net.Mail;
using System.Net;

namespace Dis1.Works
{
    public class Mail
    {
        public void sendmail(string reportwaycmp, string mailadress)
        {
            MailAddress from = new MailAddress("19capral95@gmail.com", "Faradey");
            // кому отправляем
            MailAddress to = new MailAddress(mailadress);
            // создаем объект сообщения
            MailMessage mail = new MailMessage(from, to);
            // тема письма
            mail.Subject = "Тест";
            // текст письма
            mail.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
            // письмо представляет код html
            mail.Attachments.Add(new Attachment(reportwaycmp));
            mail.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("19capral95@gmail.com", "19casper95");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        
    }
}
