using Invoices.Common;

namespace Application.Invoices.GetById;

public record GetInvoiceByIdQuery(Guid Id) : IRequest<ErrorOr<InvoiceResponse>>;

