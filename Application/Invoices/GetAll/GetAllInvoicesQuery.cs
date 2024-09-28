using Invoices.Common;

namespace Application.Invoices.GetAll;

public record GetAllInvoicesQuery() : IRequest<ErrorOr<IReadOnlyList<InvoiceResponse>>>;
