using AutoMapper;
using CleanCommander.Application.Features.Command.Commands.CreateCommand;
using CleanCommander.Application.Features.Command.Commands.PatchCommandLine;
using CleanCommander.Application.Features.Command.Commands.UpdateCommandLine;
using CleanCommander.Application.Features.Command.Queries.FindCommand;
using CleanCommander.Application.Features.Command.Queries.GetCommandDetail;
using CleanCommander.Application.Features.Command.Queries.GetCommandsList;
using CleanCommander.Application.Features.Platform.Commands.CreatePlatform;
using CleanCommander.Application.Features.Platforms.Commands.CreatePlatform;
using CleanCommander.Application.Features.Platforms.Commands.DeletePlatform;
using CleanCommander.Application.Features.Platforms.Commands.UpdatePlatform;
using CleanCommander.Application.Features.Platforms.Queries.GetPlatformById;
using CleanCommander.Application.Features.Platforms.Queries.GetPlatformsList;
using CleanCommander.Application.Models;
using CleanCommander.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.MappingProfiles
{
    public class CleanCommanderProfiles : Profile
    {
        public CleanCommanderProfiles()
        {


            CreateMap<CommandLine, GetCommandLineListByPlatformReturnModel>().ReverseMap();
            CreateMap<CommandLine, GetPlatformsListCommandDto>().ReverseMap();
            CreateMap<CommandLine, GetPlatformByIdCommandDto>().ReverseMap();
            CreateMap<CommandLine, CommandDetailsReturnModel>().ReverseMap();
            CreateMap<CommandLine, CreateCommandLineDto>().ReverseMap();
            CreateMap<CommandLine, CreateCommandLineCommand>().ReverseMap();
            CreateMap<CommandLine, PatchCommandLineDto>().ReverseMap();
            CreateMap<CommandLine, UpdateCommandLineCommand>().ReverseMap();//FindCommandReturnModel
            CreateMap<CommandLine, FindCommandReturnModel>().ReverseMap();//FindCommandReturnModel 


            CreateMap<CommandLine, CommandLineModel>().ReverseMap();


            CreateMap<PromptPlatform, GetPlatformsListReturnModel>().ReverseMap();
            CreateMap<PromptPlatform, GetPlatformByIdQueryReturnModel>().ReverseMap();
            CreateMap<PromptPlatform, UpdatePlatformCommand>().ReverseMap();
            CreateMap<PromptPlatform, CreatePlatformCommand>().ReverseMap();
            CreateMap<PromptPlatform, DeletePlatformCommand>().ReverseMap();
            CreateMap<PromptPlatform, CreatePlatformCommandDto>().ReverseMap();

            CreateMap<PromptPlatform, PromptPlatformModel>().ReverseMap();
        }
    }
}
