using ArchitectureDDD.Domain;
using FluentValidation;

namespace ArchitectureDDD.Service
{
    public class UserRoleValidator : AbstractValidator<UserRole>
    {
        public UserRoleValidator()
        {
            RuleFor(c => c.RoleId)
                .NotEmpty().WithMessage("Role Id não informado")
                .NotNull().WithMessage("Role Id não informado");

            RuleFor(c => c.UserId)
                .NotEmpty().WithMessage("User Id não informado")
                .NotNull().WithMessage("User Id não informado");
        }
    }
}
