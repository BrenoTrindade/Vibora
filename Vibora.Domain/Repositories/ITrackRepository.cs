using Vibora.Domain.Entities;

namespace Vibora.Domain.Repositories;
public interface ITrackRepository
{
    Task AddAsync(Track track);
    Task DeleteAsync(Track track);
    Task<Track?> GetByIdAsync(Guid id);
}
