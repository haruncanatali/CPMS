using CPMS.Application.Companies.Queries.Dtos;
using MediatR;

namespace CPMS.Application.Companies.Queries.GetCompany;

public class GetCompanyQuery : IRequest<CompanyDto>
{
    public long Id { get; set; }
}