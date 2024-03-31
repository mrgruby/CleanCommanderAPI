using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Responses;
using CleanCommander.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.CreateCommand
{
    public class CreateCommandLineCommandHandler : IRequestHandler<CreateCommandLineCommand, CreateResponse<CreateCommandLineDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository _repo;
        private readonly ILogger<CreateCommandLineCommandHandler> _logger;

        public CreateCommandLineCommandHandler(IMapper mapper, ICommandRepository repo, ILogger<CreateCommandLineCommandHandler> logger)
        {
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }
        public async Task<CreateResponse<CreateCommandLineDto>> Handle(CreateCommandLineCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateResponse<CreateCommandLineDto>();
            var validator = new CreateCommandLineCommandValidator();

            //Check the request to see if any of the validation rules, set up for the CreateCommandLineCommand class inside the CreateEventCommandValidator, are broken.
            //If so, add the error message to the ValidationErrors list in the validationResult.
            var validationResult = await validator.ValidateAsync(request.CommandLineModel);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }

            }
            if (response.Success)
            {
                //Map from the CommandLine request model to a CommandLine Entity, in order to add it to the database.
                var commandLine = _mapper.Map<CommandLine>(request.CommandLineModel);

                //Add to database. SaveChanges is called in the Add method.
                _repo.Add(commandLine);

                //Map from the CommandLine Entity to a CreateCommandLineDto, which is added to the response return model.
                response.Data = _mapper.Map<CreateCommandLineDto>(commandLine);
            }
            return response;
        }
    }
}
