﻿using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Extensions;

namespace Domain.ValidationModel
{
    public class ClientValidationModel : AbstractValidator<Client>
    {
        public ClientValidationModel()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(70).MinimumLength(3);
            RuleFor(c => c.Cpf).Empty().Length(11).Must(cpf => cpf.IsCpf());
            RuleFor(c => c.BirthDate).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty().Length(10);
        }
    }
}