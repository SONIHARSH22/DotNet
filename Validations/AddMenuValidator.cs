using FluentValidation;
using RestaurantManagement.Models.Request;

namespace RestaurantManagement.Validators
{
    public class AddMenuValidator : AbstractValidator<AddMenuRequest>
    {
        public AddMenuValidator()
        {
            RuleFor(menu => menu.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name must not exceed 255 characters.");

            RuleFor(menu => menu.Price)
                .NotNull().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(menu => menu.Description)
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

            RuleFor(menu => menu.AvailableQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Available quantity must be greater than or equal to 0.");

            RuleFor(menu => menu.Category)
                .NotEmpty().WithMessage("Category is required.")
                .MaximumLength(100).WithMessage("Category must not exceed 50 characters.");
        }
    }
}