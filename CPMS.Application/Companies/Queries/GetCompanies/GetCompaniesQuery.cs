using CPMS.Application.Companies.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Companies.Queries.GetCompanies;

public class GetCompaniesQuery : IRequest<List<CompanyDto>>
{
    public string? Name { get; set; }
}