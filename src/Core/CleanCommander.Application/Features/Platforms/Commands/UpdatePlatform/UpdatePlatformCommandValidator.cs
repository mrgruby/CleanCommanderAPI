using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Platforms.Commands.UpdatePlatform
{
    public class UpdatePlatformCommandValidator : AbstractValidator<UpdatePlatformCommand>
    {
        public UpdatePlatformCommandValidator()
        {
            RuleFor(p => p.PromptPlatformName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
