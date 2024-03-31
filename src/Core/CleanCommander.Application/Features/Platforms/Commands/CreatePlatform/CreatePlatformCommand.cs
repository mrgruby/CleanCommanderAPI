using CleanCommander.Application.Features.Platforms.Commands.CreatePlatform;
using CleanCommander.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platform.Commands.CreatePlatform
{
    public class CreatePlatformCommand : IRequest<CreateResponse<CreatePlatformCommandDto>>
    {
        public string PromptPlatformName { get; set; }
        public string PromptPlatformImageUrl { get; set; }
        public string PromptPlatformDescription{ get; set; }
    }
}
