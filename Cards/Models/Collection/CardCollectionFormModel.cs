namespace Cards.Models.Collection
{
    using Cards.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CardCollectionFormModel
    {
        public string Id { get; init; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Keyword { get; set; }


        public int Attack { get; set; }


        public int Health { get; set; }


        public string Description { get; set; }

        public ICollection<UserCard> Users { get; set; }

    }
}
