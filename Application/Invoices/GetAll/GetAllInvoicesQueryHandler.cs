using Invoices.Common;
using Domain.Invoices;

namespace Application.Invoices.GetAll;

internal sealed class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, ErrorOr<IReadOnlyList<InvoiceResponse>>>
{
    private readonly IInvoiceRepository _invoiceRepository;

    public GetAllInvoicesQueryHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<InvoiceResponse>>> Handle(GetAllInvoicesQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Invoice> invoices = await _invoiceRepository.GetAll();

        return invoices.Select(invoice => new InvoiceResponse(
                invoice.Id.Value,
                invoice.CustomerId.Value,
                invoice.Date,
                invoice.TotalAmount,
                invoice.InvoiceDetails.Select(detail => new InvoiceDetailResponse(
                    detail.Id.Value,
                    detail.ProductId.Value,
                    detail.Quantity,
                    detail.UnitPrice
                )).ToList()
            )).ToList();
    }
}

