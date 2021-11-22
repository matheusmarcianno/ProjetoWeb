﻿using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValidationModel
{
    public class OrderValidationModel : AbstractValidator<Order>
    {
        public OrderValidationModel()
        {
            RuleFor(o => o.OrdertDate).NotEmpty();
            RuleFor(o => o.Client).SetValidator(new ClientValidationModel());
        }
    }
}