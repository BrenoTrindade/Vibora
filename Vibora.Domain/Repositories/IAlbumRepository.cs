using Vibora.Domain.Entities;

namespace Vibora.Domain.Repositories;

public interface IAlbumRepository
{
    Task AddAsync(Album album);
    Task<Album?> GetByIdAsync(Guid id);
    Task<IEnumerable<Album>> GetAllAsync();
    Task DeleteAsync(Album album);
}
