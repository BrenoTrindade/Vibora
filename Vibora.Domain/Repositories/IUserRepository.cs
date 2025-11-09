using Vibora.Domain.Entities;

namespace Vibora.Domain.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
}
