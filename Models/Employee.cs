using Microsoft.AspNetCore.Identity;
// ReSharper disable UnusedMember.Global

namespace aspcore.Models
{
    public class User : IdentityUser
    {

        public string? Name { get; set; }
        public bool IsActive { get; set; }

    }
}
