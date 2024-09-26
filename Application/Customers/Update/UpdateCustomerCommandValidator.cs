namespace Application.Customers.Update;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();

        RuleFor(r => r.Name)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.LastName)
            .NotEmpty()
            .MaximumLength(50)
            .WithName("Last Name");

        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(r => r.Identification)
            .NotEmpty()
            .MaximumLength(9)
            .WithName("Phone Number");

        RuleFor(r => r.IsActive)
            .NotNull();
    }
}