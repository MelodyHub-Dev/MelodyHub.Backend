using AutoMapper;
using MelodyHub.Application.CQRS.Blueprints.Commands.CreateBlueprint;
using MelodyHub.Application.CQRS.Blueprints.Commands.DeleteBlueprint;
using MelodyHub.Application.CQRS.Blueprints.Commands.UpdateBlueprint;
using MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintDetails;
using MelodyHub.Application.CQRS.Blueprints.Queries.GetBlueprintList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using MelodyHub.Application.CQRS.Blueprints.Commands.UploadBlueprintImage;
using MelodyHub.Application.CQRS.Blueprints.Commands.UploadBlueprintVideo;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/blueprints")]
public class BlueprintController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<BlueprintListVm>> Get([FromQuery] Guid? instrumentId)
    {
        var query = new GetBlueprintListQuery
        {
            InstrumentId = instrumentId
        };

        var blueprints = await Mediator.Send(query);

        return Ok(blueprints);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BlueprintDetailsVm>> Get(Guid id)
    {
        var query = new GetBlueprintDetailsQuery
        {
            Id = id
        };

        var blueprint = await Mediator.Send(query);

        return Ok(blueprint);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateBlueprintDto dto)
    {
        var command = mapper.Map<CreateBlueprintCommand>(dto);

        var blueprintId = await Mediator.Send(command);

        return Ok(blueprintId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateBlueprintDto dto)
    {
        var command = mapper.Map<UpdateBlueprintCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }


    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteBlueprintCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{id:guid}/image")]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<string>> UploadImage(Guid id, IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Файл не выбран");

        var command = new UploadBlueprintImageCommand
        {
            BlueprintId = id,
            FileStream = file.OpenReadStream(),
            FileName = file.FileName,
            ContentType = file.ContentType
        };

        var url = await Mediator.Send(command);

        return Ok(new { imageUrl = url });
    }

    [HttpPost("{id:guid}/video")]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<string>> UploadVideo(Guid id, IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Файл не выбран");

        var command = new UploadBlueprintVideoCommand
        {
            BlueprintId = id,
            FileStream = file.OpenReadStream(),
            FileName = file.FileName,
            ContentType = file.ContentType
        };

        var url = await Mediator.Send(command);

        return Ok(new { videoUrl = url });
    }
}
