using System.Collections.Generic;

namespace Cards.Data.Models
{
    public class BB
    {
        public int Id { get; init; }

       public ICollection<AA> AAs { get; init; } = new HashSet<AA>();
    }
}