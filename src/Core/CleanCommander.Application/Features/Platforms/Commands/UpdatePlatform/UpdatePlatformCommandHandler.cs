using AutoMapper;
using CleanCommander.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommandHandler : IRequestHandler<UpdatePlatformCommand, UpdatePlatformCommandResponse>
    {
        private readonly IPlatformRepository _repo;
        private readonly IMapper _mapper;

        public UpdatePlatformCommandHandler(IPlatformRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }
        public async Task<UpdatePlatformCommandResponse> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdatePlatformCommandResponse();
            var validator = new UpdatePlatformCommandValidator();

            var platformFromDbToUpdate = await _repo.Get(request.PromptPlatformId);

            if (platformFromDbToUpdate == null)
            {
                response.Success = false;
                response.Message = "Notfound";
                return response;
            }

            //Check the request to see if any of the validation rules, set up for the CreateCommandLineCommand class inside the CreateEventCommandValidator, are broken.
            //If so, add the error message to the ValidationErrors list in the validationResult.
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                _mapper.Map(request, platformFromDbToUpdate);

                _repo.Update(platformFromDbToUpdate);
            }
            return response;
        }
    }
}
