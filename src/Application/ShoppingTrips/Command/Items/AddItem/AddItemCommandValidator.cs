using Application.Common.Validators;
using FluentValidation;

namespace Application.ShoppingTrips.Command.Items.AddItem
{
    public class AddItemCommandValidator : AbstractValidator<AddItemCommand>
    {
        public AddItemCommandValidator()
        {
            RuleFor(x => x.ShoppingTripItem)
                .SetValidator(new ShoppingTripItemDtoValidator());
        }
    }
}
