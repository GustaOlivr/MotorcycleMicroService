using FluentValidation;
using MotorcycleMicroService.Application.Dto.MotorcycleDto.Request;

namespace MotorcycleMicroService.Application.Validation.Motorcycle
{

    public class UpdateMotorcycleRequestValidator : AbstractValidator<UpdateMotorcycleRequest>
    {
        public UpdateMotorcycleRequestValidator()
        {
            RuleFor(x => x.Name)
                .Length(1, 100).WithMessage("The Name must be less than 100 characters");

            RuleFor(x => x.Plate)
                .Length(7,10).WithMessage("The plate must be less than 10 characters");

            RuleFor(x => x.YearManufacture)
                .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("O ano de fabricação deve estar entre 1900 e o ano atual.");
        }
    }
}
