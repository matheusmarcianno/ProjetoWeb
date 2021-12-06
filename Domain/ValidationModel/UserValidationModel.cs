using Domain.Entities;
using FluentValidation;

namespace Domain.ValidationModel
{
    public class UserValidationModel : AbstractValidator<User>
    {
        public UserValidationModel()
        {
            RuleFor(u => u.Email).NotEmpty().EmailAddress().Length(5, 100);
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Client).SetValidator(new ClientValidationModel());
            RuleFor(u => u.Restaurant).SetValidator(new RestaurantValidationModel());
        }
    }
}
