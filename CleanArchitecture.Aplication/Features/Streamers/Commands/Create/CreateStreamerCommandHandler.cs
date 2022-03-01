using AutoMapper;
using CleanArchitecture.Aplication.Contracts.Infrastructure;
using CleanArchitecture.Aplication.Contracts.Persistence;
using CleanArchitecture.Aplication.Models;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Aplication.Features.Streamers.Commands
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IStreamerRepository _streamerRepository;
        private IMapper _mapper;
        private IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(IStreamerRepository streamerRepository, IMapper mapper, IEmailService emailService, ILogger<CreateStreamerCommandHandler> logger)
        {
            _streamerRepository = streamerRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamerEntity = _mapper.Map<Streamer>(request);
            var newStreamer = await _streamerRepository.AddAsync(streamerEntity);
            _logger.LogInformation($"Streamer {newStreamer.Id} fue creado existosamente");
            await SendEamil(newStreamer);
            return newStreamer.Id;
        }

        private async Task SendEamil(Streamer streamer)
        {
            try
            {
                var email = new Email
                {
                    To = "Wigner pro",
                    Body = "La compañia se creo Correctamente",
                    Subject = "Mensaje de alerta"
                };
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Errores enviando el Email de {streamer.Id} ");
            }
        }
    }
}
