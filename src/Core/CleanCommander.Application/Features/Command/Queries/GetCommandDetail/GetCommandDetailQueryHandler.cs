using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Exceptions;
using CleanCommander.Application.Responses;
using CleanCommander.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Queries.GetCommandDetail
{
    public class GetCommandDetailQueryHandler : IRequestHandler<GetCommandDetailQuery, GetResponse<CommandDetailsReturnModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository _repo;

        public GetCommandDetailQueryHandler(IMapper mapper, ICommandRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<GetResponse<CommandDetailsReturnModel>> Handle(GetCommandDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new GetResponse<CommandDetailsReturnModel>();
            var commandLineFromDb = await _repo.GetCommandLineByPlatform(request.PlatformId, request.CommandLineId);

            if (commandLineFromDb == null)
            {
                response.Success = false;
                response.Message = $"CommandLine with Id {request.CommandLineId} was not found!";
                return response;
                throw new NotFoundException(nameof(CommandLine), request.CommandLineId);
            }
            response.Data = _mapper.Map<CommandDetailsReturnModel>(commandLineFromDb);

            return response;
        }
    }
}
