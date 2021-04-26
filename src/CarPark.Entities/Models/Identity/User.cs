using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CarPark.Entities.Models.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
}
