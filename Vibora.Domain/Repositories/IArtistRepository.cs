using Vibora.Domain.Entities;

namespace Vibora.Domain.Repositories;

public interface IArtistRepository
{
    Task<Artist?> GetByIdAsync(Guid id);
    Task<IEnumerable<Artist>> GetAllAsync();
    Task AddAsync(Artist artist);
    Task DeleteAsync(Artist artist);
}