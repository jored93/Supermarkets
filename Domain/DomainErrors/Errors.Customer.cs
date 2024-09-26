using ErrorOr;

namespace Domain.DomainErrors;

public static partial class Errors
{
    public static class Customer
    {
        public static Error IdentificationWithBadFormat => 
            Error.Validation("Customer.Identification", "Identification has not valid format.");

    }
}