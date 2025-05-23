using Microsoft.AspNetCore.Identity;

namespace Transportation.Models
{
    public class Users : IdentityUser
    {
        public DateTime Joined { get; set; }
    }
}
