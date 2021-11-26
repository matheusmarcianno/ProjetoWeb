using Domain.Entities;
using FluentValidation;

namespace Domain.ValidationModel
{
    public class OrderValidationModel : AbstractValidator<Order>
    {
        public OrderValidationModel()
        {
            RuleFor(o => o.OrdertDate).NotEmpty();
            RuleFor(o => o.Status).NotEmpty();
            RuleFor(o => o.Client).SetValidator(new ClientValidationModel());
        }
    }
}
