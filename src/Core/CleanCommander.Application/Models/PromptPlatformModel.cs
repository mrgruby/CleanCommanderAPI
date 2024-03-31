using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Models
{
    public class PromptPlatformModel
    {
        public Guid PromptPlatformId { get; set; }
        public string PromptPlatformName { get; set; }
        public string PromptPlatformImageUrl { get; set; }
        public List<CommandLineModel> CommandLineList { get; set; }
    }
}