namespace Cards.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Cat
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public string UserId { get; set; }

        public User User { get; init; }
    }
}
