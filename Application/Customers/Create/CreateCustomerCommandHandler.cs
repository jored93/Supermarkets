using MediatR;
using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Application.Customers.Create;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        if (Identification.Create(command.Identification) is not Identification identification)
        {
            throw new ArgumentException(nameof(identification));
        }

        if (CharacterString.Create(command.Name) is not CharacterString name)
        {
            throw new ArgumentException(nameof(name));
        }

        if (CharacterString.Create(command.LastName) is not CharacterString lastName)
        {
            throw new ArgumentException(nameof(lastName));
        }

        var customer = new Customer(
            new CustomerId(Guid.NewGuid()),
            name,
            lastName,
            command.Email,
            identification,
            true
        );

        _customerRepository.Add(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
