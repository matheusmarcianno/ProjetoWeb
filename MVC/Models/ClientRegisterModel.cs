using Domain.Entities;
using System;

namespace MVC.Models
{
    public class ClientRegisterModel
    {
        public string Emial { get; set; }   
        public string Password { get; set; }   
        public string Name { get; set; }   
        public string Cpf { get; set; }   
        public string PhoneNumber { get; set; }   
        public DateTime BirthDate { get; set; }

        public Client ConvertToClient()
        {
            return new Client(this.Name, this.Cpf, this.PhoneNumber, this.BirthDate);
        }

        public User ConvertToUser()
        {
            return new User(this.Emial, this.Password);
        }

    }
}
