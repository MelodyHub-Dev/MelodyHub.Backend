using AutoMapper;
using MelodyHub.Application.CQRS.InstrumentMaterials.Commands.CreateInstrumentMaterial;
using MelodyHub.Application.CQRS.InstrumentMaterials.Commands.DeleteInstrumentMaterial;
using MelodyHub.Application.CQRS.InstrumentMaterials.Commands.UpdateInstrumentMaterial;
using MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialDetails;
using MelodyHub.Application.CQRS.InstrumentMaterials.Queries.GetInstrumentMaterialList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/instrument-materials")]
public class InstrumentMaterialController(IMapper mapper) : BaseController
{
    [HttpGet("details")]
    public async Task<ActionResult<InstrumentMaterialDetailsVm>> Get([FromBody] GetInstrumentMaterialDetailsDto dto)
    {
        var query = mapper.Map<GetInstrumentMaterialDetailsQuery>(dto);

        var instrumentMaterial = await Mediator.Send(query);

        return Ok(instrumentMaterial);
    }

    [HttpGet]
    public async Task<ActionResult<InstrumentMaterialListVm>> Get()
    {
        var query = new GetInstrumentMaterialListQuery();

        var instrumentMaterials = await Mediator.Send(query);

        return Ok(instrumentMaterials);
    }

    [HttpPost("create")]
    public async Task<ActionResult> Create([FromBody] CreateInstrumentMaterialDto dto)
    {
        var command = mapper.Map<CreateInstrumentMaterialCommand>(dto);
        
        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateInstrumentMaterialDto dto)
    {
        var command = mapper.Map<UpdateInstrumentMaterialCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete")]
    public async Task<ActionResult> Delete([FromBody] DeleteInstrumentMaterialDto dto)
    {
        var command = mapper.Map<DeleteInstrumentMaterialCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }
}
