using FluentValidation;

namespace CPMS.Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(c => c.Id).NotNull()
            .WithMessage("Müşteri belirtilmelidir.");
    }
}