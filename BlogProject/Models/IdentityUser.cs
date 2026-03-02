using Microsoft.AspNetCore.Identity;

namespace BlogProject.Models
{
    public class User : IdentityUser
    {
        public int PulicationsCount { get; set; }
        public string? Name { get; set; }
    }
}
