using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Queries.GetPlatformById
{
    /// <summary>
    /// The return model for this query is a specific Platform. This will also contain a list of Command objects. This GetPlatformByIdCommandDto
    /// will represent the Command objects for the returned Platform.
    /// </summary>
    public class GetPlatformByIdCommandDto
    {
        public Guid CommandLineId { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string PromptPlatformName { get; set; }
        public string Comment { get; set; }
        public Guid PromptPlatformId { get; set; }
    }
}
