using Microsoft.AspNetCore.Identity;

namespace InvoicesAPI.Entity.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
