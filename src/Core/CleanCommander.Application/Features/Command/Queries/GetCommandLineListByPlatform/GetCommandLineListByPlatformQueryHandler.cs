using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Domain.Entities;
using CleanCommander.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanCommander.Application.Responses;
using CleanCommander.Application.Features.Command.Commands.CreateCommand;
using Microsoft.Extensions.Logging;

namespace CleanCommander.Application.Features.Command.Queries.GetCommandsList
{
    public class GetCommandLineListByPlatformQueryHandler : IRequestHandler<GetCommandLineListByPlatformQuery, GetResponse<List<GetCommandLineListByPlatformReturnModel>>>
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository _commandRepo;
        private readonly ILogger<GetCommandLineListByPlatformQueryHandler> _logger;

        public GetCommandLineListByPlatformQueryHandler(IMapper mapper, ICommandRepository commandRepo, ILogger<GetCommandLineListByPlatformQueryHandler> logger)
        {
            _mapper = mapper;
            _commandRepo = commandRepo;
            _logger = logger;
        }
        public async Task<GetResponse<List<GetCommandLineListByPlatformReturnModel>>> Handle(GetCommandLineListByPlatformQuery request, CancellationToken cancellationToken)
        {
            var response = new GetResponse<List<GetCommandLineListByPlatformReturnModel>>();

            var commandLineListFromDb = await _commandRepo.GetCommandLineListByPlatform(request.PlatformId);
            if (commandLineListFromDb == null)
            {
                response.Success = false;
                response.Message = "Un-able to retrieve a list of CommandLines.";
                return response;
                throw new NotFoundException(nameof(GetCommandLineListByPlatformReturnModel), request.PlatformId);
            }
            var commands = _mapper.Map<List<GetCommandLineListByPlatformReturnModel>>(commandLineListFromDb);
            response.Data = _mapper.Map<List<GetCommandLineListByPlatformReturnModel>>(commandLineListFromDb);

            _logger.LogInformation("Get list of commands {@commands}", commands);

            return response;
        }
    }
}
