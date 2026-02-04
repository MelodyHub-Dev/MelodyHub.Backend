using AutoMapper;
using MelodyHub.Application.CQRS.InstrumentCategories.Command.CreateInstrumentCategory;
using MelodyHub.Application.CQRS.InstrumentCategories.Command.DeleteInstrumentCategory;
using MelodyHub.Application.CQRS.InstrumentCategories.Command.UpdateInstrumentCategory;
using MelodyHub.Application.CQRS.InstrumentCategories.Queries.GetInstrumentCategoryDetails;
using MelodyHub.Application.CQRS.InstrumentCategories.Queries.GetInstrumentCategoryList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/instrument-categories")]
public class InstrumentCategoryController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<InstrumentCategoryListVm>> Get()
    {
        var query = new GetInstrumentCategoryListQuery();

        var instrumentCategories = await Mediator.Send(query);

        return Ok(instrumentCategories);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<InstrumentCategoryDetailsVm>> Get(Guid id)
    {
        var query = new GetInstrumentCategoryDetailsQuery
        {
            Id = id
        };

        var user = await Mediator.Send(query);

        return Ok(user);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateInstrumentCategoryDto dto)
    {
        var command = mapper.Map<CreateInstrumentCategoryCommand>(dto);

        var instrumentCategoryId = await Mediator.Send(command);

        return Ok(instrumentCategoryId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateInstrumentCategoryDto dto)
    {
        var command = mapper.Map<UpdateInstrumentCategoryCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteInstrumentCategoryCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
