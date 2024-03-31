using CleanCommander.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.UpdateCommandLine
{
    public class UpdateCommandLineCommand : IRequest<UpdateCommandLineCommandResponse>
    {
        public Guid CommandLineId { get; set; }
        public Guid PromptPlatformId { get; set; }

        public CommandLineModel CommandLine { get; set; }
    }
}
