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

    public async Task Add(Track track)
    {
        await _context.Tracks.AddAsync(track);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Track track)
    {
        _context.Tracks.Remove(track);
        await _context.SaveChangesAsync();
    }

    public async Task<Track> GetById(Guid id)
    {
        return await _context.Tracks.FindAsync(id);
    }
}
