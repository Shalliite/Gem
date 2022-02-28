using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Gem.WebApp.Migrations
{
    public class User : BaseEntity
    {
        public User()
        {
            LastSeen = DateTime.Now;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime LastSeen { get; set; }
        public string Password { get; set; }
        public string? VerificationCode { get; set; }
        public bool Verified { get; set; }
    }
}
