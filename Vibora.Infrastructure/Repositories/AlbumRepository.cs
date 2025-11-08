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

    public async Task Add(Album album)
    {s
        await _dbContext.Albums.AddAsync(album);

        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Album album)
    {
        _dbContext.Albums.Remove(album);    

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Album>> GetAll()
    {
        return await _dbContext.Albums.AsNoTracking().ToListAsync();
    }

    public async Task<Album?> GetById(Guid id)
    {
        return _dbContext.Albums.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
}
