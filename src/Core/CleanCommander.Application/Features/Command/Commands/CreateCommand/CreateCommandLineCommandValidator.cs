using CleanCommander.Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Features.Command.Commands.CreateCommand
{
    public class CreateCommandLineCommandValidator : AbstractValidator<CommandLineModel>
    {
        public CreateCommandLineCommandValidator()
        {
            RuleFor(p => p.HowTo)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Line)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
