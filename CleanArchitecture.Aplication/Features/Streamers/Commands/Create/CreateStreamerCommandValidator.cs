using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.Features.Streamers.Commands
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{Nombre} no puede estar vacio")
                .NotNull()
                .MaximumLength(50);
            RuleFor(p=> p.Url)
                .NotEmpty()
                .NotNull();

        }
    }
}
