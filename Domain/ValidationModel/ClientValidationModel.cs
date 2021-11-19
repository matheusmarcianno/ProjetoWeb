using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValidationModel
{
    public class ClientValidationModel : AbstractValidator<Client>
    {
        public ClientValidationModel()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(70).MinimumLength(3);
            //RuleFor(c => c.Cpf).Must(cpf => cpf.
        }
    }
}
