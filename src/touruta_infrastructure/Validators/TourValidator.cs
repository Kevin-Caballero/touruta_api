using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Touruta.Core.DTOs;

namespace Touruta.Infrastructure.Validators
{
    public class TourValidator : AbstractValidator<TourDto> 
    {
        public TourValidator()
        {
            RuleFor(tour => tour.Description)
                .NotNull()
                .Length(10, 1000);
            RuleFor(tour => tour.Date)
                .NotNull();
        }
    }
}
