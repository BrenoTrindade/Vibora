using Vibora.Domain.Entities;

namespace Vibora.Domain.Repositories;

public interface IArtistRepository
{
    Task<Artist?> GetByIdAsync(Guid id);
}