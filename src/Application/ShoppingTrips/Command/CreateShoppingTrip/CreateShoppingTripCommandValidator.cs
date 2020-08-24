using System;
using Application.Common.Dtos;
using Application.Common.Validators;
using FluentValidation;

namespace Application.ShoppingTrips.Command.CreateShoppingTrip
{
    public class CreateShoppingTripCommandValidator : AbstractValidator<CreateShoppingTripCommand>
    {
        public CreateShoppingTripCommandValidator()
        {
            // store name
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
            
            // reason of shop trip
            RuleFor(x => x.Reason)
                .NotEmpty();

            // used transportation 
            RuleFor(x => x.Transportation)
                .IsInEnum();

            // start time 
            RuleFor(x => x.StartTime)
                .NotNull()
                .GreaterThanOrEqualTo(DateTime.Now);
            
            // location validation
            RuleFor(x => x.Location)
                .SetValidator(new LocationDtoValidator());
        }
    }
}