using AutoMapper;
using MelodyHub.Application.CQRS.Instruments.Commands.CreateInstrument;
using MelodyHub.Application.CQRS.Instruments.Commands.DeleteInstrument;
using MelodyHub.Application.CQRS.Instruments.Commands.UpdateInstrument;
using MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentDetails;
using MelodyHub.Application.CQRS.Instruments.Queries.GetInstrumentList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/instruments")]
public class InstrumentController(IMapper mapper) : BaseController
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
}
