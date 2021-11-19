using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValidationModel
{
    public class UserValidationModel : AbstractValidator<User>
    {
        public UserValidationModel()
        {
            RuleFor(u => u.Email).NotEmpty().EmailAddress().MaximumLength(100).MinimumLength(5);
            RuleFor(u => u.Password).NotEmpty().GetHashCode();
        }
    }
}
