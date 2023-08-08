using CPMS.Application.Brands.Commands.CreateBrand;
using CPMS.Application.Brands.Commands.DeleteBrand;
using CPMS.Application.Brands.Commands.UpdateBrand;
using CPMS.Application.Brands.Queries.Dtos;
using CPMS.Application.Brands.Queries.GetBrand;
using CPMS.Application.Brands.Queries.GetBrands;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Api.Controllers;

public class BrandController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<BrandDto>> Get(GetBrandQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
    
    [HttpGet]
    [Route("List")]
    public async Task<ActionResult<List<BrandDto>>> GetList(GetBrandsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Create(CreateBrandCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(UpdateBrandCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(long id)
    {
        await Mediator.Send(new DeleteBrandCommand { Id = id });
        return NoContent();
    }
}