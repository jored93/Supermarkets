using Application.InvoiceDetails.Create;

namespace Application.Invoices.Create;

public record CreateInvoiceCommand(
    Guid CustomerId,
    DateTime Date,
    decimal TotalAmount,
    List<CreateInvoiceDetailCommand> InvoiceDetails
    ) : IRequest<ErrorOr<Guid>>;
