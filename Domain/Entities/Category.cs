using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Plate> Plates { get; set; }
    }
}
