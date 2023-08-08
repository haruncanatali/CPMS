using CPMS.Application.Vehicles.Commands.CreateVehicle;
using CPMS.Application.Vehicles.Commands.DeleteVehicle;
using CPMS.Application.Vehicles.Commands.UpdateVehicle;
using CPMS.Application.Vehicles.Queries.Dtos;
using CPMS.Application.Vehicles.Queries.GetVehicle;
using CPMS.Application.Vehicles.Queries.GetVehicles;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Api.Controllers;

public class VehicleController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<VehicleDto>> Get(GetVehicleQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet]
    [Route("List")]
    public async Task<ActionResult<List<VehicleDto>>> GetList(GetVehiclesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateVehicleCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(UpdateVehicleCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteVehicleCommand { Id = id });
        return NoContent();
    }
}