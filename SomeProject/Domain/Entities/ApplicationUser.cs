using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            CreationDate = DateTime.Now;
            IsEnabled = true;
            MustChangePasswordOnNextLogIn = false;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }

        public DateTime CreationDate { get; set; }
        public bool IsEnabled { get; set; }
        public bool MustChangePasswordOnNextLogIn { get; set; }
    }
}
