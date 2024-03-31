using CleanCommander.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Queries.GetCommandDetail
{
    public class GetCommandDetailQuery : IRequest<GetResponse<CommandDetailsReturnModel>>
    {
        public Guid PlatformId { get; set; }
        public Guid CommandLineId { get; set; }
    }
}
