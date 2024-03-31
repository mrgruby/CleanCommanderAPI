using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platform.Commands.CreatePlatform
{
    public class CreatePlatformCommandValidator : AbstractValidator<CreatePlatformCommand>
    {
        public CreatePlatformCommandValidator()
        {
            RuleFor(p => p.PromptPlatformName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
