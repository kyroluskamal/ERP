using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Utilities.Services.EmailService
{
    public interface IMailService
    {
        public void  SendEmail(MailRequest mailRequest);
    }
}
