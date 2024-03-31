using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Domain.Entities
{
    public class PlatformImage
    {
        public Guid ImageId { get; set; }
        public string ImageName { get; set; }
        public string ImageData { get; set; }
        public string ImageCategory { get; set; }
    }
}
