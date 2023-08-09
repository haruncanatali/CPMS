using CPMS.Application.ServicePrices.Commands.CreateServicePrice;
using CPMS.Application.ServicePrices.Commands.DeleteServicePrice;
using CPMS.Application.ServicePrices.Commands.UpdateServicePrice;
using CPMS.Application.ServicePrices.Queries.Dtos;
using CPMS.Application.ServicePrices.Queries.GetServicePrice;
using CPMS.Application.ServicePrices.Queries.GetServicePrices;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Api.Controllers;

public class ServicePriceController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<ServicePriceDto>> Get(GetServicePriceQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet]
    [Route("List")]
    public async Task<ActionResult<List<ServicePriceDto>>> GetList(GetServicePricesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateServicePriceCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(UpdateServicePriceCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteServicePriceCommand { Id = id });
        return NoContent();
    }
}