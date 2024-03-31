using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Queries.GetPlatformById
{
    public class GetPlatformByIdQueryReturnModel
    {
        public Guid PromptPlatformId { get; set; }
        public string PromptPlatformName { get; set; }
        public string PromptPlatformImageUrl { get; set; }
        public ICollection<GetPlatformByIdCommandDto> CommandLineList { get; set; }
    }
}
