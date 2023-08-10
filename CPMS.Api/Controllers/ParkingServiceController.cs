using CPMS.Application.ParkingServices.Commands.CreateParkingService;
using CPMS.Application.ParkingServices.Commands.DeleteParkingService;
using CPMS.Application.ParkingServices.Commands.UpdateParkingService;
using CPMS.Application.ParkingServices.Queries.Dtos;
using CPMS.Application.ParkingServices.Queries.GetParkingService;
using CPMS.Application.ParkingServices.Queries.GetParkingServices;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Api.Controllers;

public class ParkingServiceController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<ParkingServiceDto>> Get(GetParkingServiceQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet]
    [Route("List")]
    public async Task<ActionResult<List<ParkingServiceDto>>> GetList(GetParkingServicesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateParkingServiceCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(UpdateParkingServiceCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteParkingServiceCommand { Id = id });
        return NoContent();
    }
}