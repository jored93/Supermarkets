using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers;

public sealed class Customer : AggregateRoot
{
    public Customer(CustomerId id, string name, string lastName, string email, Identification identification, bool isActive)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        Identification = identification;
        IsActive = isActive;
    }

    private Customer(){
        
    }

    public CustomerId Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string FullName => $"{Name} {LastName}";
    public string Email { get; private set; } = string.Empty;
    public Identification Identification { get; private set; }
    public bool IsActive { get; set; }

    public static Customer UpdateCustomer(Guid id, string name, string lastName, string email, Identification identification, bool active)
    {
        return new Customer(new CustomerId(id), name, lastName, email, identification, active);
    }
}