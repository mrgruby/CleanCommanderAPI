using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Features.Command.Queries.GetCommandsList;
using Microsoft.EntityFrameworkCore;
using CleanCommander.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Persistence.Repositories
{
    /// <summary>
    /// Inherit from the GenericRepository with a specific type, and implement the specific ICommandRepository
    /// </summary>
    public class CommandRepository : GenericRepository<CommandLine>, ICommandRepository
    {
        public CommandRepository(CleanCommanderDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<CommandLine> GetCommandLineByPlatform(Guid platformId, Guid commandLineId)
        {
            return await _dbContext.CommandLines.Where(x => x.PromptPlatformId == platformId && x.CommandLineId == commandLineId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CommandLine>> GetCommandLineListByPlatform(Guid platformId)
        {
            return await _dbContext.CommandLines.Where(x => x.PromptPlatformId == platformId).ToListAsync();
        }
    }
}
