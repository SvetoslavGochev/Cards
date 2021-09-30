namespace Cards.Models.Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AddCardCollectionFormModel
    {

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Keyword { get; set; }


        public int Attack { get; set; }


        public int Health { get; set; }


        public string Description { get; set; }

    }
}
