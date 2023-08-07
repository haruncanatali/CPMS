using CPMS.Application.Auth.Queries.Dtos;
using CPMS.Application.Companies.Commands.CreateCompany;
using CPMS.Application.Companies.Commands.DeleteCompany;
using CPMS.Application.Companies.Commands.UpdateCompany;
using CPMS.Application.Companies.Queries.GetCompany;
using CPMS.Application.Users.Queries.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Api.Controllers;

public class CompanyController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<UserDto>> Get([FromQuery]GetCompanyQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<LoginDto>> Create(CreateCompanyCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UserDto>> Update(UpdateCompanyCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> Delete(long id)
    {
        await Mediator.Send(new DeleteCompanyCommand { Id = id });
        return NoContent();
    }
}