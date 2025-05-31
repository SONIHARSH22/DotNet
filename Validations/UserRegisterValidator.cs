using FluentValidation;
using RestaurantManagement.Models.Request;

namespace RestaurantManagement.Validations
{
    public class UserRegisterValidator : AbstractValidator<RegisterRequest>
    {
        public UserRegisterValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(user => user.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches("^\\d{10}$").WithMessage("Phone number must be 10 digits.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[@$!%*?&#]").WithMessage("Password must contain at least one special character.");

            RuleFor(user => user.Role)
                .NotEmpty().WithMessage("Role is required.");
        }
    }
}
