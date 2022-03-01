using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.Features.Streamers.Commands.Update
{
    public class UptadeStreamerValidator : AbstractValidator<UpdateStreamerCommand>
    {
        public UptadeStreamerValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Url).NotEmpty();
        }
    }
}
