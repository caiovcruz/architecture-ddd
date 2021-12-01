using ArchitectureDDD.Domain;
using FluentValidation;

namespace ArchitectureDDD.Service
{
    public class UserLoginValidator : AbstractValidator<UserLoginViewModel>
    {
        public UserLoginValidator()
        {
            RuleFor(c => c.UserName)
                .NotEmpty().WithMessage("Please enter the username.")
                .NotNull().WithMessage("Please enter the username.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Please enter the password.")
                .NotNull().WithMessage("Please enter the password.");
        }
    }
}
