using CPMS.Application.Settings.Commands.CreateSetting;
using CPMS.Application.Settings.Commands.DeleteSetting;
using CPMS.Application.Settings.Commands.UpdateSetting;
using CPMS.Application.Settings.Queries.Dtos;
using CPMS.Application.Settings.Queries.GetSetting;
using CPMS.Application.Settings.Queries.GetSettings;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Api.Controllers;

public class SettingController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<SettingDto>> Get([FromQuery]GetSettingQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet]
    [Route("List")]
    public async Task<ActionResult<List<SettingDto>>> GetList(GetSettingsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateSettingCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(UpdateSettingCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteSettingCommand { Id = id });
        return NoContent();
    }
}