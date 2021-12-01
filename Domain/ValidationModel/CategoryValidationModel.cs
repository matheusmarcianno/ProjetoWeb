using Domain.Entities;
using Domain.Extensions;
using FluentValidation;

namespace Domain.ValidationModel
{
    public class CategoryValidationModel : AbstractValidator<Category>
    {
        public CategoryValidationModel()
        {
            RuleFor(c => c.Name).NotEmpty().Length(3, 50);
        }
    }
}
