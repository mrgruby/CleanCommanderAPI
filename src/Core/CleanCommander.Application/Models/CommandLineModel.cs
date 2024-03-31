using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Models
{
    public class CommandLineModel
    {
        public Guid CommandLineId { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        public string PromptPlatformName { get; set; }
        public string Comment { get; set; }
        public Guid PromptPlatformId { get; set; }
        public PromptPlatformModel Platform { get; set; }
    }
}
