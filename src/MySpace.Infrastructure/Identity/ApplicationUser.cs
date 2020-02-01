using Microsoft.AspNetCore.Identity;

namespace MySpace.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Avatar { get; set; }
    }
}
