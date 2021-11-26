using Domain.Entities;
using FluentValidation;

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
