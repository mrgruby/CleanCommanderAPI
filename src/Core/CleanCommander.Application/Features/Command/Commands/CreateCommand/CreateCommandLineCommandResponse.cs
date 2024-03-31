using CleanCommander.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.CreateCommand
{
    public class CreateCommandLineCommandResponse : BaseResponse
    {
        public CreateCommandLineCommandResponse() : base()
        {

        }

        //This is the newly created CommandLine. It is added to the response, so it can be returned in the http response header
        public CreateCommandLineDto CommandLineDto { get; set; }
    }
}
