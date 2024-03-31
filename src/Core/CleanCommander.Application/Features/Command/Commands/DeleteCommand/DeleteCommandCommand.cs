using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.DeleteCommand
{
    public class DeleteCommandCommand : IRequest<DeleteCommandLineCommandResponse>
    {
        public Guid CommandLineId { get; set; }
        public Guid PromptPlatformId { get; set; }
    }
}
