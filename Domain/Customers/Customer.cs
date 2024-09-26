using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers;

public sealed class Customer : AggregateRoot
{
    public Customer(CustomerId id, CharacterString name, CharacterString lastName, string email, Identification identification, bool isActive)
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
    public CharacterString Name { get; private set; }
    public CharacterString LastName { get; private set; }
    public string FullName => $"{Name} {LastName}";
    public string Email { get; private set; } = string.Empty;
    public Identification Identification { get; private set; }
    public bool IsActive { get; set; }
}