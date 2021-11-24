using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }

        public User() { }

        public User(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public User SetClient(int clientId)
        {
            this.ClientId = clientId;
            return this;
        }

        public User SetRestaurant(int restaurnatId)
        {
            this.RestaurantId = restaurnatId;
            return this;
        }
    }
}
