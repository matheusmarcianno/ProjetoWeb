using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; } 
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
