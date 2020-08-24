using Application.Common.Dtos;
using FluentValidation;

namespace Application.Common.Validators
{
    public class LocationDtoValidator : AbstractValidator<LocationDto>
    {
        public LocationDtoValidator()
        {
            // placeid, google maps
            RuleFor(x => x.PlaceId)
                .NotEmpty()
                .MaximumLength(255);

            // name of store
            RuleFor(x => x.StoreName)
                .NotEmpty()
                .MaximumLength(255);

            // address formatted
            RuleFor(x => x.FormattedAddress)
                .NotEmpty()
                .MaximumLength(500);

            // rating of store
            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 10);
        }
    }
}