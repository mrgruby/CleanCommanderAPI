using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Features.Command.Commands.CreateCommand;
using CleanCommander.Application.MappingProfiles;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using CleanCommander.Domain.Entities;
using FluentAssertions;
using MediatR;
using CleanCommander.Application.Tests.Mocks;

namespace CleanCommander.Application.Tests.CommandTests
{
    public class CreateCommandLineHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICommandRepository> _mockCommandRepository;
        private readonly Mock<CreateCommandLineCommandHandler> _mockCreateCommandLineCommandHandler;
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<CreateCommandLineCommandHandler>> _logger;

        public CreateCommandLineHandlerTest()
        {
            _mockCommandRepository = new();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CleanCommanderProfiles>();
            });

            _mapper = configurationProvider.CreateMapper();

            //var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new CleanCommanderProfiles()));
            //IMapper mapper = new Mapper(configuration);


            _logger = new Mock<ILogger<CreateCommandLineCommandHandler>>();
            _mockCreateCommandLineCommandHandler = new();
            _mediator= new Mock<IMediator>();

        }
        [Fact]
        public async Task CreateCommandLineTest()
        {
            //Create a new handler with the mocked dependencies. The handler will work as normal, but with test data.
            var handler = new CreateCommandLineCommandHandler(_mapper, _mockCommandRepository.Object, _logger.Object);

            //Create a request-command to send to the handler. This is the same as a request from the controller.
            var handlerCommand = new CreateCommandLineCommand { CommandLineModel = CommandRepositoryMocks.GetCommandLineModel() };

            //Run the handler, and test that it creates and returns the correct response type
            var result = await handler.Handle(handlerCommand, default);
            result.Should().BeOfType<CreateCommandLineCommandResponse>();
            
            //result.CommandLineDto.CommandLineId.Should().Be("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE");

            //Get a hordcoded list of commands
            var commands = CommandRepositoryMocks.GetCommandLineList();

            //Setup the GetAll method of the mocked repository to return a list of CommandLines. These would normally come from the database. 
            _mockCommandRepository.Setup(p => p.All()).ReturnsAsync(commands);


            //var commandLineToAdd = _mapper.Map<CommandLine>(result.CommandLineDto);
            //commands.Add(commandLineToAdd);
            var allCommands = await _mockCommandRepository.Object.All();
            allCommands.Should().HaveCount(5);
        }
    }
}
