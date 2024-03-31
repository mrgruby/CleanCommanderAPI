using CleanCommander.Application.Features.Platforms.Commands.CreatePlatform;
using CleanCommander.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platform.Commands.CreatePlatform
{
    public class CreatePlatformCommandResponse : BaseResponse
    {
        public CreatePlatformCommandResponse() : base()
        {

        }

        public CreatePlatformCommandDto CreatePlatformCommandDto { get; set; }
    }
}
