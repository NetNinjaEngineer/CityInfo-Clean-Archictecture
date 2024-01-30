using FluentValidation;

namespace CityInfo.Application.DTOs.PointOfInterest.Validators
{
    public class PointOfInterestForManipulationValidator : AbstractValidator<PointOfInterestForManipulation>
    {
        public PointOfInterestForManipulationValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("You should fill out the name.")
                .MaximumLength(50).WithMessage("Maximum Length allowed for name is 50 characters.")
                .MinimumLength(20).WithMessage("The name must be at least 20 characters.")
                .NotNull();

            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("You should fill out the category.")
                .MaximumLength(50).WithMessage("Maximum Length allowed for category is 50 characters.")
                .NotNull();

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("You should fill out the description.")
                .MaximumLength(200).WithMessage("Maximum Length allowed for description is 50 characters.")
                .NotNull();

            RuleFor(p => p.Latitude)
                .NotEmpty().WithMessage("You should fill out the latitude.")
                .NotNull();

            RuleFor(p => p.Longitude)
                .NotEmpty().WithMessage("You should fill out the longitude.")
                .NotNull();

        }
    }
}