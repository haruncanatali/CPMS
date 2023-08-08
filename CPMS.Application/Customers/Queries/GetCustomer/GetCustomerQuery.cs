using CPMS.Application.Customers.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Customers.Queries.GetCustomer;

public class GetCustomerQuery : IRequest<CustomerDto>
{
    public long Id { get; set; }
}