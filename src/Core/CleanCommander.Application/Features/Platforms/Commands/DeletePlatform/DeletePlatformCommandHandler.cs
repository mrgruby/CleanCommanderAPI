using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand, DeletePlatformResponse>
    {
        private readonly IPlatformRepository _repo;
        private readonly IMapper _mapper;

        public DeletePlatformCommandHandler(IPlatformRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<DeletePlatformResponse> Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
        {
            var platformToDeleteFromDb = await _repo.Get(request.PromptPlatformId);

            var response = new DeletePlatformResponse();

            if (platformToDeleteFromDb == null)
            {
                response.Success = false;
                response.Message = "NotFound";
            }

            _repo.Delete(platformToDeleteFromDb);

            return response;
        }
    }
}
