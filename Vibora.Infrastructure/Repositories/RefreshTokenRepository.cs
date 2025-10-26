using Microsoft.EntityFrameworkCore;
using Vibora.Domain.Entities;
using Vibora.Domain.Repositories;
using Vibora.Infrastructure.Persistence;

namespace Vibora.Infrastructure.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly ViboraDbContext _context;
    public RefreshTokenRepository(ViboraDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task AddAsync(RefreshToken token)
    {
        await _context.AddAsync(token);
        await _context.SaveChangesAsync();
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == token);
    }

    public async Task UpdateAsync(RefreshToken token)
    {
        _context.RefreshTokens.Update(token);
        await _context.SaveChangesAsync();
    }
}
