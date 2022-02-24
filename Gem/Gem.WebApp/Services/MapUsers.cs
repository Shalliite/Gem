using Gem.WebApp.Migrations;
using Gem.WebApp.Models;

namespace Gem.WebApp.Services
{
    public class MapUsers
    {
        public User Map(RegistrationModel rm)
        {
            return new User
            {
                Email = rm.Email,
                Name = rm.FirstName,
                Surname = rm.LastName,
                MiddleName = rm.MiddleName,
                Password = PasswordHash.Hash(rm.Password)
            };
        }
        public User Map(LoginModel lm)
        {
            return new User
            {
                Email = lm.Email,
                Password = PasswordHash.Hash(lm.Password)
            };
        }
    }
}
