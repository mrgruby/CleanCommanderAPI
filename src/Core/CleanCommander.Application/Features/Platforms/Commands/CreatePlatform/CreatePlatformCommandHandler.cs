using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using CleanCommander.Application.Exceptions;
using CleanCommander.Application.Features.Platforms.Commands.CreatePlatform;
using CleanCommander.Application.Responses;
using CleanCommander.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platform.Commands.CreatePlatform
{
    public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, CreateResponse<CreatePlatformCommandDto>>
    {
        private readonly IPlatformRepository _repo;
        private readonly IMapper _mapper;

        public CreatePlatformCommandHandler(IPlatformRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<CreateResponse<CreatePlatformCommandDto>> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateResponse<CreatePlatformCommandDto>();//Success is set to true by default
            var validator = new CreatePlatformCommandValidator();

            //Check the request to see if any of the validation rules, set up for the CreateCommandLineCommand class inside the CreateEventCommandValidator,
            //are broken.If so, add the error message to the ValidationErrors list in the validationResult.
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                //These are located in the BaseResponse class
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
                throw new ValidationException(validationResult);
            }
            if (response.Success)//Success is set to true by default
            {
                var platformToAdd =_mapper.Map<PromptPlatform>(request);

                _repo.Add(platformToAdd);

                response.Data = _mapper.Map<CreatePlatformCommandDto>(platformToAdd);
            }

            return response;
        }
    }
}
