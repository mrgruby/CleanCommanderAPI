using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Queries.GetPlatformById
{
    public class GetPlatformByIdQueryHandler : IRequestHandler<GetPlatformByIdQuery, GetResponse<GetPlatformByIdQueryReturnModel>>
    {
        private readonly IPlatformRepository _repo;
        private readonly IMapper _mapper;

        public GetPlatformByIdQueryHandler(IPlatformRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GetResponse<GetPlatformByIdQueryReturnModel>> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetResponse<GetPlatformByIdQueryReturnModel>();
            var platformFormDb = await _repo.GetPlatformByIdWithCommands(request.PromptPlatformId);
            if (platformFormDb == null)
            {
                response.Message = $"Platform with id {request.PromptPlatformId} was not found";
                response.Success = false;
                return response;
            }
            response.Data = _mapper.Map<GetPlatformByIdQueryReturnModel>(platformFormDb);
            return response;
        }
    }
}
