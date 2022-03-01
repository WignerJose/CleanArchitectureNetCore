using MediatR;

namespace CleanArchitecture.Aplication.Features.Streamers.Commands.Update
{
    public class UpdateStreamerCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty ;
    }
}
