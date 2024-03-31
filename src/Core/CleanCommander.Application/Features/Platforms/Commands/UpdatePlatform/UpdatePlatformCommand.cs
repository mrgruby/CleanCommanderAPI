using CleanCommander.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommand : IRequest<UpdatePlatformCommandResponse>
    {
        public Guid PromptPlatformId { get; set; }
        public string PromptPlatformName { get; set; }
        public string PromptPlatformImageUrl { get; set; }
        public List<CommandLineModel> CommandLineList { get; set; }
    }
}
