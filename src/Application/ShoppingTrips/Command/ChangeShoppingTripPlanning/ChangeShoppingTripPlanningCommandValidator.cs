using System;
using Application.Common.Validators;
using FluentValidation;

namespace Application.ShoppingTrips.Command.ChangeShoppingTripPlanning
{
    public class ChangeShoppingTripPlanningCommandValidator : AbstractValidator<ChangeShoppingTripPlanningCommand>
    {
        public ChangeShoppingTripPlanningCommandValidator()
        {
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