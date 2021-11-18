using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Plate : EntityBase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public ICollection<Order>  Orders { get; set; }
    }
}
