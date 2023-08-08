using CPMS.Application.Customers.Commands.CreateCustomer;
using CPMS.Application.Customers.Commands.DeleteCustomer;
using CPMS.Application.Customers.Commands.UpdateCustomer;
using CPMS.Application.Customers.Queries.Dtos;
using CPMS.Application.Customers.Queries.GetCustomer;
using CPMS.Application.Customers.Queries.GetCustomers;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Api.Controllers;

public class CustomerController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<CustomerDto>> Get(GetCustomerQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet]
    [Route("List")]
    public async Task<ActionResult<List<CustomerDto>>> GetList(GetCustomersQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateCustomerCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(UpdateCustomerCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteCustomerCommand { Id = id });
        return NoContent();
    }
}