namespace ERP.Utilities.Services.EmailService
{
    public interface IMailService
    {
        public void SendEmail(MailRequest mailRequest);
    }
}
