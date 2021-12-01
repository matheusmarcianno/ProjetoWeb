using Domain.Entities;
using FluentValidation;

namespace Domain.ValidationModel
{
	public class PlateValidationModel : AbstractValidator<Plate>
	{
		public PlateValidationModel()
		{
			RuleFor(p => p.Price).NotEmpty();
			RuleFor(p => p.Description).NotEmpty().Length(10, 150);
			RuleFor(p => p.Restaurant).SetValidator(new RestaurantValidationModel());
			RuleFor(p => p.Category).SetValidator(new CategoryValidationModel());
		}
	}
}

