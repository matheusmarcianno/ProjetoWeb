using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : EntityBase
    {
        public DateTime OrdertDate { get { return DateTime.Now; } }
        public Status Status {get; set;}
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public ICollection<Plate> Plates { get; set; }
    }
}
