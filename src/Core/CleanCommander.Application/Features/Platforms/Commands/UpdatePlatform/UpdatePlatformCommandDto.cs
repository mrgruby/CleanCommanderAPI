using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommandDto
    {
        public string PromptPlatformName { get; set; }
        public string PromptPlatformImageUrl { get; set; }
    }
}
