using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValidationModel
{
    public class CategoryValidationModel : AbstractValidator<Category>
    {
        public CategoryValidationModel()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
        }
    }
}
