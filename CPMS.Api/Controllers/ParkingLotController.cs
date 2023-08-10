using CPMS.Application.ParkingLots.Commands.CreateParkingLot;
using CPMS.Application.ParkingLots.Commands.DeleteParkingLot;
using CPMS.Application.ParkingLots.Commands.UpdateParkingLot;
using CPMS.Application.ParkingLots.Queries.Dtos;
using CPMS.Application.ParkingLots.Queries.GetParkingLot;
using CPMS.Application.ParkingLots.Queries.GetParkingLots;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Api.Controllers;

public class ParkingLotController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<ParkingLotDto>> Get(GetParkingLotQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet]
    [Route("List")]
    public async Task<ActionResult<List<ParkingLotDto>>> GetList(GetParkingLotsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateParkingLotCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(UpdateParkingLotCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteParkingLotCommand { Id = id });
        return NoContent();
    }
}