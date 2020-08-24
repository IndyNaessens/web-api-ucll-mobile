using FluentValidation;

namespace Application.ShoppingTrips.Command.ChangeShoppingTripInfo
{
    public class ChangeShoppingTripInfoCommandValidator : AbstractValidator<ChangeShoppingTripInfoCommand>
    {
        public ChangeShoppingTripInfoCommandValidator()
        {
            // store name
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);
            
            // reason of shop trip
            RuleFor(x => x.Reason)
                .NotEmpty();
        }
    }
}