using Gem.WebApp.Migrations;
using Gem.WebApp.Models;

namespace Gem.WebApp.Services
{
    public class MapUsers
    {
        /// <summary>
        /// This function maps RegistrationModel to the User.
        /// </summary>
        /// <param name="rm"></param>
        /// <returns>User used for storing data into database with hashed password</returns>
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

        /// <summary>
        /// This function maps LoginModel to the User.
        /// </summary>
        /// <param name="lm"></param>
        /// <returns>User used for checking login with hashed password</returns>
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
