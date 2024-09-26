using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Application.Customers.Update;

internal sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ErrorOr<Unit>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<Unit>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        if (!await _customerRepository.ExistsAsync(new CustomerId(command.Id)))
        {
            return Error.NotFound("Customer.NotFound", "The customer with the provide Id was not found.");
        }

        if (Identification.Create(command.Identification) is not Identification identification)
        {
            return Error.Validation("Customer.Identification", "Identification has not valid format.");
        }

        Customer customer = Customer.UpdateCustomer(
            command.Id,
            command.Name,
            command.LastName,
            command.Email,
            identification,
            command.IsActive);

        _customerRepository.Update(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
