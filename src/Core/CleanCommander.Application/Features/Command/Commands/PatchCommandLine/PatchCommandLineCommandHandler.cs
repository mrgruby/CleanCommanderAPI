using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Exceptions;
using CleanCommander.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.PatchCommandLine
{
    public class PatchCommandLineCommandHandler : IRequestHandler<PatchCommandLineCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository _repo;
        private readonly ILogger<PatchCommandLineCommandHandler> _logger;

        public PatchCommandLineCommandHandler(IMapper mapper, ICommandRepository repo, ILogger<PatchCommandLineCommandHandler> logger)
        {
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }
        public async Task<Unit> Handle(PatchCommandLineCommand request, CancellationToken cancellationToken)
        {
            //Get the commandline entity to update
            var commandLineFromDb = await _repo.GetCommandLineByPlatform(request.PromptPlatformId, request.CommandLineId);

            //If it doesn't exist, throw exception
            if (commandLineFromDb == null)
            {
                throw new NotFoundException(nameof(CommandLine), request.CommandLineId);
            }

            //Convert the commandline entity to a commandLineDto, in order to add it to the json patch document.
            var commandLineDto = _mapper.Map<PatchCommandLineDto>(commandLineFromDb);

            //Add the values from the patch document, to the DTO
            request.CommmandLineToUpdatePatch.ApplyTo(commandLineDto);

            //Check if any validation rules are broken
            var validator = new PatchCommandLineCommandValidator();
            var validationResult = await validator.ValidateAsync(commandLineDto);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);


            //Map it back to a commandline entity, so it can be updated in the db 
            _mapper.Map(commandLineDto, commandLineFromDb);

            _repo.Update(commandLineFromDb);
            return Unit.Value;
        }
    }
}