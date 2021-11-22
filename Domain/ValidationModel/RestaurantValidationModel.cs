using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Extensions;

namespace Domain.ValidationModel
{
    public class RestaurantValidationModel : AbstractValidator<Restaurant>
    {
        public RestaurantValidationModel()
        {
            RuleFor(r => r.Name).NotEmpty().MaximumLength(70).MinimumLength(3);
            RuleFor(r => r.PhoneNumber).NotEmpty().Length(10);
            RuleFor(r => r.Cnpj).Empty().Length(11).Must(cnpj => cnpj.IsCnpj());
        }
    }
}
