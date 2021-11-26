using System.Collections.Generic;

namespace Domain.Entities
{
    public class Plate : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }  
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public ICollection<Order>  Orders { get; set; }
    }
}
