namespace Cards.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {

        public string Name { get; init; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Cat> Cats { get; set; } = new HashSet<Cat>();

        public ICollection<UserCard> Cards { get; init; } = new HashSet<UserCard>();


    }
}
