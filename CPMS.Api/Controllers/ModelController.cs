using CPMS.Application.Models.Commands.CreateModel;
using CPMS.Application.Models.Commands.DeleteModel;
using CPMS.Application.Models.Commands.UpdateModel;
using CPMS.Application.Models.Queries.Dtos;
using CPMS.Application.Models.Queries.GetModel;
using CPMS.Application.Models.Queries.GetModels;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Api.Controllers;

public class ModelController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<ModelDto>> Get(GetModelQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet]
    [Route("List")]
    public async Task<ActionResult<List<ModelDto>>> GetList(GetModelsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateModelCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(UpdateModelCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteModelCommand() { Id = id });
        return NoContent();
    }
}