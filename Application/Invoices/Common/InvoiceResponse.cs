namespace Invoices.Common;

public record InvoiceResponse(
    Guid Id,
    Guid CustomerId,
    DateTime Date,
    decimal TotalAmount,
    List<InvoiceDetailResponse> InvoiceDetails
);

