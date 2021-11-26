using Domain.Entities;
using FluentValidation;

namespace Domain.ValidationModel
{
    public class UserValidationModel : AbstractValidator<User>
    {
        public UserValidationModel()
        {
            RuleFor(u => u.Email).NotEmpty().EmailAddress().MaximumLength(100).MinimumLength(5);
            RuleFor(u => u.Password).NotEmpty().GetHashCode();
            RuleFor(u => u.Client).SetValidator(new ClientValidationModel());
            RuleFor(u => u.Restaurant).SetValidator(new RestaurantValidationModel());
        }
    }
}
