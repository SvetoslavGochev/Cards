namespace Cards.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        //public ICollection<Card> Cards { get; set; } = new HashSet<Card>();

        //public ICollection<Cat> Cats { get; set; } = new HashSet<Cat>();

    }
}
