using Gem.WebApp.Migrations;

namespace Gem.WebApp.Services
{
    public class UserRepository
    {
        private readonly ApplicationDbContext dbc;

        /// <summary>
        /// Constructs new application database context. Used to manipulate database.
        /// </summary>
        /// <param name="adbc"></param>
        public UserRepository(ApplicationDbContext adbc)
        {
            dbc = adbc;
        }

        /// <summary>
        /// This function will add new user to the database.
        /// </summary>
        /// <param name="user">Takes new user to be stored into database.</param>
        /// <exception cref="ArgumentNullException">If user input is null.</exception>
        public void Add(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User must not be null");
            dbc.Users.Add(user);
            dbc.SaveChanges();
        }

        /// <summary>
        /// Checks if email is already registered into the database.
        /// </summary>
        /// <param name="email">Email to check</param>
        /// <returns>True if it is registered. False if it is not.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool IsRegistered(string email)
        {
            if (email == null)
                throw new ArgumentNullException("Cannot check email that is provided, cause it is null!");
            if (dbc.Users.Any(x => x.Email == email))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if provided password matches in the database stored one.
        /// </summary>
        /// <param name="email">Email linked to the account with the password you want to check</param>
        /// <param name="passwordToCheck">Password you want to check</param>
        /// <returns>True if entered password matches. False if it is not.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool IsPasswordCorrect(string email, string passwordToCheck)
        {
            if (passwordToCheck == null)
                throw new ArgumentNullException("Cannot check password that is provided, cause it is null!");
            if (IsRegistered(email))
            {
                //Should not be null, cause its value is checked before
                if (dbc.Users.Where(x => x.Email == email).FirstOrDefault().Password == passwordToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        public void ChangePassword(string email, string password)
        {
            if (IsRegistered(email))
            {
                dbc.Users.Where(x => x.Email == email).FirstOrDefault().Password = PasswordHash.Hash(password);
                dbc.SaveChanges();
            }
        }

        public void StoreVerificationCode(string code, string email)
        {
            if (IsRegistered(email))
            {
                dbc.Users.Where(x => x.Email == email).FirstOrDefault().VerificationCode = code;
                dbc.SaveChanges();
            }
        }
        public void DeleteVerificationCode(string email)
        {
            if (IsRegistered(email))
            {
                dbc.Users.Where(x => x.Email == email).FirstOrDefault().VerificationCode = null;
                dbc.SaveChanges();
            }
        }

        public string GetVerificationCode(string email)
        {
            if (IsRegistered(email))
            {
                return dbc.Users.Where(x => x.Email == email).FirstOrDefault().VerificationCode;
            }
            return null;
        }
    }
}
