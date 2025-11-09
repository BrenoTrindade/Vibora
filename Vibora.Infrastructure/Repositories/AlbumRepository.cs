using Microsoft.EntityFrameworkCore;
using Vibora.Domain.Entities;
using Vibora.Domain.Repositories;
using Vibora.Infrastructure.Persistence;

namespace Vibora.Infrastructure.Repositories;
public class AlbumRepository : IAlbumRepository
{
    private readonly ViboraDbContext _dbContext;
    public AlbumRepository(ViboraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Album album)
    {
        await _dbContext.Albums.AddAsync(album);

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Album album)
    {
        _dbContext.Albums.Remove(album);    

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Album>> GetAllAsync()
    {
        return await _dbContext.Albums.AsNoTracking().ToListAsync();
    }

    public async Task<Album?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Albums.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
}
