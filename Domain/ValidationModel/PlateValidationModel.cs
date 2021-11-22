﻿using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
