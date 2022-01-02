using Microsoft.AspNetCore.Identity;
using System;

namespace CustomIdentity.Models
{
    public class AppUser:IdentityUser<Guid>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public string UserRole { get; set; }

    }
}
