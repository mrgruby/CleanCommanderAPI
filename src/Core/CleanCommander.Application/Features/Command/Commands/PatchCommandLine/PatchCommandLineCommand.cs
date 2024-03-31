using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.PatchCommandLine
{
    public class PatchCommandLineCommand : IRequest
    {
        public JsonPatchDocument<PatchCommandLineDto> CommmandLineToUpdatePatch { get; set; }
        public Guid CommandLineId { get; set; }
        public Guid PromptPlatformId { get; set; }
    }
}
