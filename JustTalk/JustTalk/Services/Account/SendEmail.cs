using System.Net;
using System.Net.Mail;

namespace JustTalk.Services.Account
{

    public class SendEmail
    {
        internal bool sendToNewUser()
        {

            using (var smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;

                var msg = new MailMessage()
                {
                    From = new MailAddress("EldoNawolno@gmail.com"),
                    Subject = "lol"
                };

                msg.To.Add(new MailAddress("jakub.sroka96@gmail.com"));
                msg.Body = "nje";
                msg.IsBodyHtml = false;
                smtp.EnableSsl = true;
                smtp.Send(msg);

            }
            
            return true;
        }



    }
}
