using FluentValidation;
using Application.InvoiceDetails.Create;

namespace Application.Invoices.Create;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        RuleFor(r => r.CustomerId)
            .NotEmpty();

        RuleFor(r => r.Date)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(r => r.TotalAmount)
            .GreaterThan(0);

        RuleForEach(r => r.InvoiceDetails)
            .SetValidator(new CreateInvoiceDetailCommandValidator());
    }
}

