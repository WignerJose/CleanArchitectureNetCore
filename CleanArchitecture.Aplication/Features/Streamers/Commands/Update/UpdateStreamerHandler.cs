using AutoMapper;
using CleanArchitecture.Aplication.Contracts.Persistence;
using CleanArchitecture.Aplication.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.Features.Streamers.Commands.Update
{
    public class UpdateStreamerHandler : IRequestHandler<UpdateStreamerCommand>
    {
        private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStreamerHandler> _logger;

        public UpdateStreamerHandler(IStreamerRepository streamerRepository, IMapper mapper, ILogger<UpdateStreamerHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerToUpdate = await _streamerRepository.GetByIdAsync(request.Id);
            if (streamerToUpdate == null)
                throw new NotFoundException(nameof(streamerToUpdate), request.Id);

            _mapper.Map(request, streamerToUpdate, typeof(UpdateStreamerCommand), typeof(Streamer));
            await _streamerRepository.UpdateAsync(streamerToUpdate);
            _logger.LogInformation($"La actualizacion del streamer fue exitosa");
            return Unit.Value;
        }
    }
}
