using ErrorOr;
using GuildManagerCA.Application.ClassSpecializations.Commands.Create;
using GuildManagerCA.Application.ClassSpecializations.Queries.GetAll;
using GuildManagerCA.Application.ClassSpecializations.Queries.GetById;
using GuildManagerCA.Contracts.ClassSpecializations.Create;
using GuildManagerCA.Contracts.ClassSpecializations.GetAll;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerCA.Api.Controllers;

[Route("api/[controller]")]
public class SpecializationsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public SpecializationsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll([FromQuery] bool onlyActive = false)
    {
        var query = _mapper.Map<GetAllSpecializationsQuery>(onlyActive);
        var queryResult = await _mediator.Send(query);

        return queryResult.Match(
            specializations => Ok(specializations.Select(spec => _mapper.Map<SpecializationResponse>(spec))),
            errors => Problem(errors)
            );
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var query = new GetSpecializationByIdQuery(id);
        var queryResult = await _mediator.Send(query);

        return queryResult.Match(
            specialization => Ok(_mapper.Map<SpecializationResponse>(specialization)),
            errors => Problem(errors)
            );
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateSpecializationRequest request)
    {
        var command = _mapper.Map<CreateSpecializationCommand>(request);
        ErrorOr<CreateSpecializationResult> result = await _mediator.Send(command);

        return result.Match(
            specResult =>
            {
                var response = _mapper.Map<CreateSpecializationResponse>(specResult);
                return Created("api/specializations/get/", response.Id);
            },
            errors => Problem(errors));


    }
}
