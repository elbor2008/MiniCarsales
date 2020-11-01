using FluentValidation;
using MiniCarsales.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarsales.Api.Validators
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Make).NotEmpty().WithMessage("make is mandatory")
                .MaximumLength(20).WithMessage("length of make should be less than {MaxLength}");
            RuleFor(c => c.Model).NotEmpty().WithMessage("model is mandatory")
                .MaximumLength(20).WithMessage("length of model should be less than {MaxLength}");
            RuleFor(c => c.Engine).NotEmpty().WithMessage("engine is mandatory")
                .MaximumLength(20).WithMessage("length of engine should be less than {MaxLength}");
            RuleFor(c => c.Doors).Must(d => d == 2 || d == 4).WithMessage("doors should be 2 or 4");
            RuleFor(c => c.Wheels).InclusiveBetween(4, 6).WithMessage("wheels should be between 4 and 6");
            RuleFor(c => c.VehicleType).IsInEnum().WithMessage("vehicle type is out of range");
            RuleFor(c => c.BodyType).IsInEnum().WithMessage("body type is out of range");
        }
    }
}
