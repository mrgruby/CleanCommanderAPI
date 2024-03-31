using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Queries.GetCommandsList
{
    public class GetCommandLineListByPlatformReturnModel
    {
        //public List<GetCommandLineListPlatformDto> CommandLinesByPlatformsList { get; set; }
        public Guid CommandLineId { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string PromptPlatformName { get; set; }
        public string Comment { get; set; }
        public Guid PromptPlatformId { get; set; }
    }
}
