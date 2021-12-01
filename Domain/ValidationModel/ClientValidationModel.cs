using Domain.Entities;
using FluentValidation;
using Domain.Extensions;

namespace Domain.ValidationModel
{
    public class ClientValidationModel : AbstractValidator<Client>
    {
        public ClientValidationModel()
        {
            RuleFor(c => c.Name).NotEmpty().Length(3, 70);
            RuleFor(c => c.Cpf).NotEmpty().Length(11).Must(cpf => cpf.IsCpf());
            RuleFor(c => c.Cep).NotEmpty().Length(8);
            RuleFor(c => c.BirthDate).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty().Length(11);
        }
    }
}
