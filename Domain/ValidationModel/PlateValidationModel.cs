using Domain.Entities;
using FluentValidation;

namespace Domain.ValidationModel
{
	public class PlateValidationModel : AbstractValidator<Plate>
	{
		public PlateValidationModel()
		{
			RuleFor(p => p.Price).NotEmpty();
			RuleFor(p => p.Description).NotEmpty().MaximumLength(150).MinimumLength(10);
		}
	}
}

