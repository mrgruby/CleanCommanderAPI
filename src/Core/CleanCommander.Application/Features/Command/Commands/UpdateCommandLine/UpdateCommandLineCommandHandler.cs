using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.UpdateCommandLine
{
    public class UpdateCommandLineCommandHandler : IRequestHandler<UpdateCommandLineCommand, UpdateCommandLineCommandResponse>
    {
        private readonly ICommandRepository _repo;
        private readonly IMapper _mapper;

        public UpdateCommandLineCommandHandler(ICommandRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<UpdateCommandLineCommandResponse> Handle(UpdateCommandLineCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateCommandLineCommandResponse();
            var validator = new UpdateCommandLineCommandValidator();

            //Get the command we want to update from the database. Use the id's from the request.
            var commandLineFromDbToUpdate = await _repo.GetCommandLineByPlatform(request.PromptPlatformId, request.CommandLineId);

            //If the command does not exist, return a failed response.
            if (commandLineFromDbToUpdate == null)
            {
                response.Success = false;
                response.Message = "Notfound";
                return response;
            }

            //Check the request to see if any of the validation rules, set up for the CreateCommandLineCommand class inside the CreateEventCommandValidator, are broken.
            //If so, add the error message to the ValidationErrors list in the validationResult.
            var validationResult = await validator.ValidateAsync(request.CommandLine);

            if (validationResult.Errors.Count > 0)
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
                _mapper.Map(request.CommandLine, commandLineFromDbToUpdate);

                _repo.Update(commandLineFromDbToUpdate);
            }
            return response;
        }
    }
}
