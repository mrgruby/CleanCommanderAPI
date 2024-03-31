using CleanCommander.Application.Features.Command.Queries.GetCommandsList;
using CleanCommander.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Contracts.Persistence
{
    public interface ICommandRepository : IGenericRepository<CommandLine>
    {
        Task<IEnumerable<CommandLine>>GetCommandLineListByPlatform(Guid platformId);
        Task<CommandLine> GetCommandLineByPlatform(Guid platformId, Guid commandLineId);
    }
}
