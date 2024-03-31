using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Exceptions;
using CleanCommander.Application.Features.Command.Queries.GetCommandsList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Queries.FindCommand
{
    public class FindCommandQueryHandler : IRequestHandler<FindCommandQuery, List<FindCommandReturnModel>>
    {
        private readonly IMapper _mapper;
        private readonly ICommandRepository _commandRepo;

        public FindCommandQueryHandler(IMapper mapper, ICommandRepository commandRepo)
        {
            _mapper = mapper;
            _commandRepo = commandRepo;
        }

        public async Task<List<FindCommandReturnModel>> Handle(FindCommandQuery request, CancellationToken cancellationToken)
        {
            var commands = await _commandRepo.Find(c => c.HowTo.Contains(request.SearchTerm));

            if (commands == null)
                throw new NotFoundException(nameof(FindCommandReturnModel), request.SearchTerm);

            return _mapper.Map<List<FindCommandReturnModel>>(commands);
        }
    }
}
