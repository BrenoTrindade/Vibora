using Vibora.Domain.Entities;

namespace Vibora.Domain.Repositories;
public interface ITrackRepository
{
    Task Add(Track track);
    Task Delete(Track track);
    Task<Track> GetById(Guid id);
}
