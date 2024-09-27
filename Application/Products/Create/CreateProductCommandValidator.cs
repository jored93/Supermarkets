using FluentValidation;

namespace Application.Products.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(r => r.Description)
            .MaximumLength(500);

        RuleFor(r => r.Price)
            .GreaterThan(0);

        RuleFor(r => r.CategoryId)
            .NotEmpty();

        RuleFor(r => r.IsActive)
            .NotNull();
    }
}

