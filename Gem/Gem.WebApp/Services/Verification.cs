using Gem.WebApp.Migrations;
using System.Net;
using System.Net.Mail;

namespace Gem.WebApp.Services
{
    public class Verification
    {
        private UserRepository _userRepository;
        private int min = 000000;
        private int max = 999999;
        public Verification(ApplicationDbContext adbc)
        {
            _userRepository = new UserRepository(adbc);
        }
        public void SendCode(string email, string subject, string body)
        {
            Random random = new Random();
            string codeUnhashed = random.Next(min, max).ToString("D6");
            _userRepository.StoreVerificationCode(PasswordHash.Hash(codeUnhashed), email);
            SendEmail(email, subject, body + $" {codeUnhashed}");
        }

        public bool CheckCode(string email, string code)
        {
            if(email == null)
                throw new ArgumentNullException("Cannot check null emails!");
            if(_userRepository.GetVerificationCode(email) == PasswordHash.Hash(code))
            {
                _userRepository.DeleteVerificationCode(email);
                return true;
            }
            return false;
        }
        private void SendEmail(string email, string subject, string body)
        {
            using (MailMessage mm = new MailMessage("gemchatapp@gmail.com", email))
            {
                mm.Subject = subject;
                mm.Body = body;

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("gemchatapp@gmail.com", "GEMchatAPP2022");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }
        }
    }
}
