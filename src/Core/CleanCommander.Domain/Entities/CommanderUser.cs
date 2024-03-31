using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Domain.Entities
{
    public class CommanderUser
    {
        [Key]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string PassWordHash { get; set; }
    }
}
