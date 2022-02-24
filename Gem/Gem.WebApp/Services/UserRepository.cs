using Gem.WebApp.Migrations;

namespace Gem.WebApp.Services
{
    public class UserRepository
    {
        private readonly ApplicationDbContext dbc;
        public UserRepository(ApplicationDbContext adbc)
        {
            dbc = adbc;
        }
        public void Add(User user)
        {
            dbc.Users.Add(user);
            dbc.SaveChanges();
        }
        public bool IsRegistered(string email)
        {
            if(dbc.Users.Any(x => x.Email == email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsPasswordCorrect(string email, string passwordToCheck)
        {
            if (IsRegistered(email))
            {
                if (dbc.Users.Where(x => x.Email == email).FirstOrDefault().Password == passwordToCheck)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
