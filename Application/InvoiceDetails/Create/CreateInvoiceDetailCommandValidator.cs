using FluentValidation;

namespace Application.InvoiceDetails.Create;

public class CreateInvoiceDetailCommandValidator : AbstractValidator<CreateInvoiceDetailCommand>
{
    public CreateInvoiceDetailCommandValidator()
    {
        RuleFor(r => r.ProductId)
            .NotEmpty();

        RuleFor(r => r.Quantity)
            .GreaterThan(0);

        RuleFor(r => r.UnitPrice)
            .GreaterThan(0);
    }
}

