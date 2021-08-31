using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices.SendEmail
{
    public interface ISendEmailService
    {
        public Task<bool> send(string email);
        public Task<bool> SendRegisterEmail(string toEmail);
        public Task<bool> SendContatcsEmail(string email);
    }
}
