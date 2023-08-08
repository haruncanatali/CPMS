using CPMS.Application.Common.Interfaces;
using CPMS.Domain.Entities;
using CPMS.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CPMS.Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<Unit>
{
    public long Id { get; set; }
    
    public class Handler : IRequestHandler<DeleteCustomerCommand,Unit>
    {
        private readonly IApplicationContext _context;

        public Handler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer? customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (customer != null)
            {
                customer.EntityStatus = EntityStatus.Passive;
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            return Unit.Value;
        }
    }
}