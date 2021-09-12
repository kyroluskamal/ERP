using Microsoft.Extensions.Options;
using MimeKit;
//using MailKit.Net.Smtp;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace ERP.Utilities.Services.EmailService
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public  void SendEmail(MailRequest mailRequest)
        {
            MailMessage msgMail = new MailMessage();

            MailMessage myMessage = new MailMessage( );
            myMessage.From = new MailAddress(_mailSettings.Mail, _mailSettings.DisplayName);
            myMessage.To.Add(mailRequest.ToEmail);
            myMessage.Subject = mailRequest.Subject;
            myMessage.IsBodyHtml = true;
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        //(Stream contentStream, string? name, string ? mediaType
                        var attachment = new Attachment(file.FileName);
                        myMessage.Attachments.Add(attachment);
                    }
                }
            }
            myMessage.Body = mailRequest.Body;

            SmtpClient mySmtpClient = new SmtpClient();
            NetworkCredential myCredential = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            mySmtpClient.Host = _mailSettings.Host;
            mySmtpClient.Port = _mailSettings.Port;
            
            mySmtpClient.UseDefaultCredentials = false;
            mySmtpClient.Credentials = myCredential;
            mySmtpClient.ServicePoint.MaxIdleTime = 1;

            mySmtpClient.Send(myMessage);
            myMessage.Dispose();
        }
    }
}
