using ArchitectureDDD.Domain;
using FluentValidation;

namespace ArchitectureDDD.Service
{
    public class RoleValidator : AbstractValidator<RoleViewModel>
    {
        public RoleValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter the name.")
                .NotNull().WithMessage("Please enter the name.");
        }
    }
}
