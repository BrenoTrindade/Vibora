using Vibora.Domain.Entities;
using Vibora.Domain.Repositories;
using Vibora.Infrastructure.Persistence;

namespace Vibora.Infrastructure.Repositories;
public class TrackRepository : ITrackRepository
{
    private readonly ViboraDbContext _context;
    public TrackRepository(ViboraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Track track)
    {
        await _context.Tracks.AddAsync(track);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Track track)
    {
        _context.Tracks.Remove(track);
        await _context.SaveChangesAsync();
    }

    public async Task<Track?> GetByIdAsync(Guid id)
    {
        return await _context.Tracks.FindAsync(id);
    }
}
