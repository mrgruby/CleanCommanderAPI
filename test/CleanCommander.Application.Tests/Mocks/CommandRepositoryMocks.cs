using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Models;
using CleanCommander.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Tests.Mocks
{
    public static class CommandRepositoryMocks
    {
        public static List<CommandLine> GetCommandLineList()
        {
            var DockerGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var EntityFrameworkGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var GithubGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var KubernetesGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            var commands = new List<CommandLine>
            {
                new CommandLine
                {
                    PromptPlatformId = DockerGuid,
                    CommandLineId = EntityFrameworkGuid,
                    HowTo = "Build docker image"
                },
                new CommandLine
                {
                    PromptPlatformId = DockerGuid,
                    CommandLineId = DockerGuid,
                    HowTo = "Create new migration"
                },
                new CommandLine
                {
                    PromptPlatformId = DockerGuid,
                    CommandLineId = KubernetesGuid,
                    HowTo = "Push to github"
                },
                new CommandLine
                {
                    PromptPlatformId = DockerGuid,
                    CommandLineId = EntityFrameworkGuid,
                    HowTo = "View all pods"
                },
            };

            var mock = new Mock<ICommandRepository>();

            mock.Setup(repo => repo.GetCommandLineListByPlatform(DockerGuid)).ReturnsAsync(commands);

            //mock.Verify(p => p.Add(It.Is<CommandLine>(c => c.CommandLineId ))

            //mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
            //    (Category category) =>
            //    {
            //        categories.Add(category);
            //        return category;
            //    });

            return commands;
        }

        public static CommandLineModel GetCommandLineModel()
        {
            var commandLineId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var platformId = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");

            return new CommandLineModel
            {
                CommandLineId = commandLineId,
                Comment = "Comment",
                HowTo = "Howto",
                Line = "CommandLine text",
                PromptPlatformId = platformId,
                PromptPlatformName = "PromptPlatformName"
            };
        }
    }
}
