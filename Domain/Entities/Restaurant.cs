using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Restaurant : EntityBase
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string PhoneNumber { get; set; }

        public Restaurant() { }

        public Restaurant(string name, string cnpj, string phoneNumber)
        {
            this.Name = name;
            this.Cnpj = cnpj;
            this.PhoneNumber = phoneNumber;
        }
    }
}
