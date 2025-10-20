using Microsoft.EntityFrameworkCore;
using Vibora.Domain.Entities;

namespace Vibora.Infrastructure.Persistence;

public class ViboraDbContext : DbContext
{
    public ViboraDbContext(DbContextOptions options) : base(options) {}

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ViboraDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
