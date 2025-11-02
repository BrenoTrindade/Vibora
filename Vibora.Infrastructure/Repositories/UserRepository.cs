using Microsoft.EntityFrameworkCore;
using Vibora.Domain.Entities;
using Vibora.Domain.Repositories;
using Vibora.Infrastructure.Persistence;

namespace Vibora.Infrastructure.Repositories;

public class UserRepository: IUserRepository
{
    private readonly ViboraDbContext _context;

    public UserRepository(ViboraDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
    
    public async Task<User?> GetByIdAsync(Guid guid)
    {
        return await _context.Users.FindAsync(guid);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}
