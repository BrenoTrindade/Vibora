using Microsoft.EntityFrameworkCore;
using Vibora.Domain.Entities;
using Vibora.Domain.Repositories;
using Vibora.Infrastructure.Persistence;

namespace Vibora.Infrastructure.Repositories;

public class ArtistRepository : IArtistRepository
{
    private readonly ViboraDbContext _context;

    public ArtistRepository(ViboraDbContext context)
    {
        _context = context;
    }

    public async Task<Artist?> GetByIdAsync(Guid id)
    {
        return await _context.Artists
            .Include(a => a.Albums)
            .Include(a => a.Tracks)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }
}