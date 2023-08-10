using CPMS.Application.ParkPrices.Commands.CreateParkPrice;
using CPMS.Application.ParkPrices.Commands.DeleteParkPrice;
using CPMS.Application.ParkPrices.Commands.UpdateParkPrice;
using CPMS.Application.ParkPrices.Queries.Dtos;
using CPMS.Application.ParkPrices.Queries.GetParkPrice;
using CPMS.Application.ParkPrices.Queries.GetParkPrices;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Api.Controllers;

public class ParkPriceController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<ParkPriceDto>> Get(GetParkPriceQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet]
    [Route("List")]
    public async Task<ActionResult<List<ParkPriceDto>>> GetList(GetParkPricesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateParkPriceCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(UpdateParkPriceCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteParkPriceCommand { Id = id });
        return NoContent();
    }
}