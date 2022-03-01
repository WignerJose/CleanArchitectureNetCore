using CleanArchitecture.Domain;

namespace CleanArchitecture.Aplication.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<IEnumerable<Video>> GetVideoByName(string videoName);
        Task<IEnumerable<Video>> GetVideoByUserName(string userName);

    }
}
