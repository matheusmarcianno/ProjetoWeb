using System.Collections.Generic;

namespace Domain.Entities
{
    public class Restaurant : EntityBase
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Plate> Plates { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Restaurant() { }

        public Restaurant(string name, string cnpj, string phoneNumber)
        {
            this.name = name;
            this.Cnpj = cnpj;
            this.PhoneNumber = phoneNumber;
        }
    }
}
