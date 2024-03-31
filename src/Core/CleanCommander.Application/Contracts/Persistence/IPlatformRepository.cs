using CleanCommander.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Contracts.Persistence
{
    public interface IPlatformRepository : IGenericRepository<PromptPlatform>
    {
        Task<IEnumerable<PromptPlatform>> GetPlatformsWithCommands();

        Task<PromptPlatform> GetPlatformByIdWithCommands(Guid id);

        //Task<IEnumerable<PlatformImage>> GetPlatformImages();
    }
}
