using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.DeleteCommand
{
    public class DeleteCommandCommandHandler : IRequestHandler<DeleteCommandCommand, DeleteCommandLineCommandResponse>
    {
        private readonly ICommandRepository _repo;
        private readonly IMapper _mapper;

        public DeleteCommandCommandHandler(ICommandRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<DeleteCommandLineCommandResponse> Handle(DeleteCommandCommand request, CancellationToken cancellationToken)
        {
            var commandLineToDelete = await _repo.GetCommandLineByPlatform(request.PromptPlatformId, request.CommandLineId);

            var response = new DeleteCommandLineCommandResponse();

            if (commandLineToDelete == null)
            {
                response.Success = false;
                response.Message = "NotFound";
            }

            _repo.Delete(commandLineToDelete);

            return response;
        }
    }
}
