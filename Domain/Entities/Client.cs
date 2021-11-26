using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Client : EntityBase
    {
        public string Name { get; set; }
        public string Cpf { get; set; } 
        public string Cep { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Client() { }

        public Client(string name, string cpf, string phoneNumber, DateTime birthDate)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.PhoneNumber = phoneNumber;
            this.BirthDate = birthDate;
        }
    }
}
