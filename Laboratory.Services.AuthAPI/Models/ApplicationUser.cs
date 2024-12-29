using Microsoft.AspNetCore.Identity;

namespace Laboratory.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public string Name { get; set; }

    }
}
