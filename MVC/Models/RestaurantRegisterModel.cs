using Domain.Entities;

namespace MVC.Models
{
    public class RestaurantRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string PhoneNumber { get; set; }

        public Restaurant ConvertToRestaurant()
        {
            return new Restaurant(this.Name, this.Cnpj, this.Password);
        }

        public User ConvertToUser()
        {
            return new User(this.Email, this.Password);
        }
    }
}
