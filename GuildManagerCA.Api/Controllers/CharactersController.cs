﻿using GuildManagerCA.Application.Characters.Queries;
using GuildManagerCA.Application.Characters.Queries.GetAllCharacters;
using GuildManagerCA.Application.Characters.Queries.GetUserCharacters;
using GuildManagerCA.Contracts.Characters;
using GuildManagerCA.Domain.Common.Errors;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuildManagerCA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ApiController
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public CharactersController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCharactersQuery();

            var result = await _sender.Send(query);

            if(result.Value is not null && result.Value.Count > 0)
            {
                return NoContent();
            }

            return result.Match(
                characters => Ok(_mapper.Map<List<CharacterResponse>>(result.Value!)),
                errors => Problem(errors)
                );
        }

        [HttpGet("mine")]
        public async Task<IActionResult> GetUserCharacters()
        {
            var result = await _sender.Send(new GetUserCharactersQuery());

            if (result.IsError && result.FirstError == Errors.Authentication.UserContextIdNull)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: result.FirstError.Description
                    );
            }

            return result.Match(
                chars => Ok(_mapper.Map<List<CharacterResponse>>(result.Value)),
                errors => Problem(errors)
                );
        }

        
    }
}
