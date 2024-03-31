using CleanCommander.Application.Features.Command.Queries.FindCommand;
using CleanCommander.Application.Features.Platform.Commands.CreatePlatform;
using CleanCommander.Application.Features.Platforms.Commands.CreatePlatform;
using CleanCommander.Application.Features.Platforms.Commands.DeletePlatform;
using CleanCommander.Application.Features.Platforms.Commands.UpdatePlatform;
using CleanCommander.Application.Features.Platforms.Queries.GetPlatformById;
using CleanCommander.Application.Features.Platforms.Queries.GetPlatformsList;
using CleanCommander.Application.Responses;
using CleanCommander.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanCommander.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlatformController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //api/platform/{id}/commandlines

        //https://localhost:44363/api/platform/
        [HttpGet(Name = "GetAllPlatforms")]
        public async Task<ActionResult<List<GetPlatformsListReturnModel>>> Get()
        {
            var dtos = await _mediator.Send(new GetPlatformsListQuery());

            return Ok(dtos);
        }

        //TODO: The returnmodel is wrong! It returns a list of platforms, when it should return a single Platform.....S
        //https://localhost:44363/api/platform/6313179F-7837-473A-A4D5-A5571B43E6A6
        [HttpGet("{promptPlatformId:Guid}", Name = "GetPlatformById")]
        public async Task<ActionResult<GetResponse<GetPlatformByIdQueryReturnModel>>> Get(Guid promptPlatformId)
        {
            var platform = await _mediator.Send(new GetPlatformByIdQuery { PromptPlatformId = promptPlatformId });

            if (platform == null)
                return NotFound($"The platform with id {promptPlatformId}, was not found");
            return Ok(platform);
        }

        /// <summary>
        /// This is used to search for commands, where the commandline contains the searchterm. This would be a search bar in the UI.
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        //https://localhost:44363/api/platform/{searchTerm}
        [HttpGet("{searchTerm}", Name = "FindCommands")]
        public async Task<ActionResult<List<FindCommandReturnModel>>> Find(string searchTerm)
        {
            var commands = await _mediator.Send(new FindCommandQuery { SearchTerm = searchTerm });

            if (commands == null)
                return NotFound($"No commands were found, when searching for the term {searchTerm} ");
            return Ok(commands);
        }

        //https://localhost:44363/api/platform/
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CreateResponse<CreatePlatformCommandDto>>> Post(CreatePlatformCommand platform)
        {
            var response = await _mediator.Send(platform);

            //TODO: I think I need to map to a read dto first, and then return that here....
            if (response.Success)
                return CreatedAtRoute("GetPlatformById", new { PromptPlatformId = response.Data.PromptPlatformId }, response);
            else
                return BadRequest($"Failed to save new Platform - {string.Join(", ", response.ValidationErrors)}");
        }

        /// <summary>
        /// Update platform, including the list of commands
        /// </summary>
        /// <param name="platformToUpdate"></param>
        /// <returns></returns>
        /// 
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<UpdatePlatformCommandResponse>> Put(UpdatePlatformCommand platformToUpdate)
        {
            var response = await _mediator.Send(platformToUpdate);

            if (response.Success == false && response.Message == "Notfound")
                return NotFound($"Platform to upate, with Id {platformToUpdate.PromptPlatformId}, was not found!");
            if (response.Success == false && response.ValidationErrors.Count > 0)
                return BadRequest($"Failed to update Platform - {string.Join(", ", response.ValidationErrors)}");

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{promptPlatformId:Guid}")]
        public async Task<ActionResult<DeletePlatformResponse>> Delete(Guid promptPlatformId)
        {
            var response = await _mediator.Send(new DeletePlatformCommand { PromptPlatformId = promptPlatformId });

            if (response.Success == false && response.Message == "NotFound")
                return NotFound($"Platform to delete, with Id {promptPlatformId}, was not found!");

            return NoContent();
        }
    }
}
