using Microsoft.AspNetCore.Identity;

namespace MUDling.Models
{
    public class AppUser : IdentityUser
    {
        public int UserId { get; set; }
    }
}