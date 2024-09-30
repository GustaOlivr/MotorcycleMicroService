using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;


namespace MotorcycleMicroService.Application.Validation.Motorcycle
{

    public class CreateMotorcycleRequestValidator : AbstractValidator<CreateMotorcycleRequest>
    {
        public CreateMotorcycleRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The Name is required")
                .Length(1, 100).WithMessage("The Name must be less than 100 characters");

            RuleFor(x => x.Plate)
                .NotEmpty().WithMessage("The Plate is required")
                .Length(7,10).WithMessage("The plate must be less than 10 characters");

            RuleFor(x => x.YearManufacture)
                .InclusiveBetween(1885, DateTime.Now.Year).WithMessage("The year of manufacture must be between 1885 and the current year.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("The Type of motorcycle is required");

        }
    }
}
