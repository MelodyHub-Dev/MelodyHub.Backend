using AutoMapper;
using MelodyHub.Application.CQRS.Instruments.Commands.CreateInstrument;
using MelodyHub.Application.CQRS.Instruments.Commands.DeleteInstrument;
using MelodyHub.Application.CQRS.Instruments.Commands.UpdateInstrument;
using MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentDetails;
using MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentList;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Domain;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MelodyHub.Application.Interfaces;
using MelodyHub.Application.CQRS.Instruments.Commands.UploadInstrumentImage;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/instruments")]
public class InstrumentController(IMapper mapper, IMelodyHubDbContext context) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<InstrumentListVm>> Get()
    {
        var query = new GetInstrumentListQuery();

        var instruments = await Mediator.Send(query);

        return Ok(instruments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InstrumentDetailVm>> Get(Guid id)
    {
        var query = new GetInstrumentDetailsQuery
        {
            Id = id
        };

        var instrument = await Mediator.Send(query);

        return Ok(instrument);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateInstrumentDto dto)
    {
        var command = mapper.Map<CreateInstrumentCommand>(dto);

        var instrument = await Mediator.Send(command);

        return Ok(instrument);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateInstrumentDto dto)
    {
        var command = mapper.Map<UpdateInstrumentCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteInstrumentCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPost("{id:guid}/views")]
    public async Task<ActionResult> IncrementViews(Guid id)
    {
        var instrument = await context.Instruments.FindAsync([id])
            ?? throw new NotFoundException(nameof(Instrument), id);

        instrument.ViewsCount++;
        await context.SaveChangesAsync(CancellationToken.None);

        return Ok(new { viewsCount = instrument.ViewsCount });
    }

    [HttpPost("{id:guid}/image")]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<string>> UploadImage(Guid id, IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Файл не выбран");

        var command = new UploadInstrumentImageCommand
        {
            InstrumentId = id,
            FileStream = file.OpenReadStream(),
            FileName = file.FileName,
            ContentType = file.ContentType
        };

        var url = await Mediator.Send(command);

        return Ok(new { imageUrl = url });
    }
}
