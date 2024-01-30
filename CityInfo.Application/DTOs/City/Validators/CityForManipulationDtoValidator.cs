using FluentValidation;

namespace CityInfo.Application.DTOs.City.Validators
{
    public class CityForManipulationDtoValidator : AbstractValidator<CityForManipulationDto>
    {
        public CityForManipulationDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("You should fill out the name.")
                .NotNull()
                .MaximumLength(100).WithMessage("The Name shouldn't have more than 100 characters.");


            RuleFor(p => p.Country)
                .NotEmpty().WithMessage("You should fill out the country.")
                .NotNull()
                .MaximumLength(100).WithMessage("The Country shouldn't have more than 100 characters.");

            RuleFor(p => p.Population)
                .GreaterThan(0).WithMessage("Population must be greater than zero");

        }
    }
}