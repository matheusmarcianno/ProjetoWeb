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
        public int Id { get; set; }
        public DateTime OrdertDate { get; set; }
        public Status Status {get; set;}
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<Plate> Plates { get; set; }
    }
}
