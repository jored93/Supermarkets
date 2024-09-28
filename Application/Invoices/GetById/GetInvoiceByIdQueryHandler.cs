using Invoices.Common;
using Domain.Invoices;

namespace Application.Invoices.GetById;

internal sealed class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, ErrorOr<InvoiceResponse>>
{
    private readonly IInvoiceRepository _invoiceRepository;

    public GetInvoiceByIdQueryHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
    }

    public async Task<ErrorOr<InvoiceResponse>> Handle(GetInvoiceByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _invoiceRepository.GetByIdAsync(new InvoiceId(query.Id)) is not Invoice invoice)
        {
            return Error.NotFound("Invoice.NotFound", "The invoice with the provided Id was not found.");
        }

        return new InvoiceResponse(
            invoice.Id.Value,
            invoice.CustomerId.Value,
            invoice.Date,
            invoice.TotalAmount,
            invoice.InvoiceDetails.Select(detail => new InvoiceDetailResponse(
                detail.Id.Value,
                detail.ProductId.Value,
                detail.Quantity,
                detail.UnitPrice
            )).ToList());
    }
}

