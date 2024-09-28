using MediatR;
using Domain.Invoices;
using Domain.Customers;
using Domain.Primitives;
using Domain.DomainErrors;
using Domain.Products;

namespace Application.Invoices.Create;

public sealed class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, ErrorOr<Guid>>
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Guid>> Handle(CreateInvoiceCommand command, CancellationToken cancellationToken)
    {
        if (!await _customerRepository.ExistsAsync(new CustomerId(command.CustomerId)))
        {
            return Errors.Customer.IdentificationWithBadFormat;
        }

        var invoice = new Invoice(
            new InvoiceId(Guid.NewGuid()),
            new CustomerId(command.CustomerId),
            command.Date,
            command.TotalAmount
        );

        foreach (var detail in command.InvoiceDetails)
        {
            invoice.AddInvoiceDetail(new InvoiceDetail(
                new InvoiceDetailId(Guid.NewGuid()),
                invoice.Id,
                new ProductId(detail.ProductId),
                detail.Quantity,
                detail.UnitPrice
            ));
        }

        _invoiceRepository.Add(invoice);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return invoice.Id.Value;
    }
}

