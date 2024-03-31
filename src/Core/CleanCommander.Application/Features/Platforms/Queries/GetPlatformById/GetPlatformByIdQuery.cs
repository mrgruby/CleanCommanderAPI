using CleanCommander.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Queries.GetPlatformById
{
    public class GetPlatformByIdQuery : IRequest<GetResponse<GetPlatformByIdQueryReturnModel>>
    {
        public Guid PromptPlatformId { get; set; }
    }
}
