namespace Cards.Data.Models
{

    using System.Collections.Generic;


    public class AA
    {
        public int Id { get; init; }

      public ICollection<BB> BBs { get; init; } = new HashSet<BB>();
    }
}
