using Customers.Common;
using Domain.Customers;

namespace Application.Customers.GetAll;


internal sealed class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ErrorOr<IReadOnlyList<CustomerResponse>>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<CustomerResponse>>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Customer> customers = await _customerRepository.GetAll();

        return customers.Select(customer => new CustomerResponse(
                customer.Id.Value,
                customer.FullName,
                customer.Email,
                customer.Identification.Value,
                customer.IsActive
            )).ToList();
    }
}