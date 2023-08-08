using CPMS.Application.Customers.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Customers.Queries.GetCustomers;

public class GetCustomersQuery : IRequest<List<CustomerDto>>
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? IdentificationNumber { get; set; }
}