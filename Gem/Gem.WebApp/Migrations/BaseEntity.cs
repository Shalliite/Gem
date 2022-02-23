using System.ComponentModel.DataAnnotations;

namespace Gem.WebApp.Migrations
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual int User_ID { get; set; }
    }
}
