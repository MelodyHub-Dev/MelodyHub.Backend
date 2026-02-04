using AutoMapper;
using MelodyHub.Application.CQRS.Materials.Commands.CreateMaterial;
using MelodyHub.Application.CQRS.Materials.Commands.DeleteMaterial;
using MelodyHub.Application.CQRS.Materials.Commands.UpdateMaterial;
using MelodyHub.Application.CQRS.Materials.Queries.GetMaterialDetails;
using MelodyHub.Application.CQRS.Materials.Queries.GetMaterialList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/materials")]
public class MaterialController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<MaterialListVm>> Get()
    {
        var query = new GetMaterialListQuery();

        var materials = await Mediator.Send(query);

        return Ok(materials);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MaterialDetailsVm>> Get(Guid id)
    {
        var query = new GetMaterialDetailsQuery
        {
            Id = id
        };

        var material = await Mediator.Send(query);

        return Ok(material);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateMaterialDto dto)
    {
        var command = mapper.Map<CreateMaterialCommand>(dto);

        var materialId = await Mediator.Send(command);

        return Ok(materialId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateMaterialDto dto)
    {
        var command = mapper.Map<UpdateMaterialCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteMaterialCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
