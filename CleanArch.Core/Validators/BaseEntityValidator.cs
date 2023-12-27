using FluentValidation;
using MyProject.Domain.Common;

public class BaseEntityValidator : AbstractValidator<BaseEnity>
{
    public BaseEntityValidator()
    {
        RuleFor(entity => entity.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name length should not exceed 50 characters.");
    }
}
