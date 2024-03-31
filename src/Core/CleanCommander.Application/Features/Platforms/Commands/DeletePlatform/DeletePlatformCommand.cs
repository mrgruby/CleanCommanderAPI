using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Commands.DeletePlatform
{
    public class DeletePlatformCommand : IRequest<DeletePlatformResponse>
    {
        public Guid PromptPlatformId { get; set; }
    }
}
