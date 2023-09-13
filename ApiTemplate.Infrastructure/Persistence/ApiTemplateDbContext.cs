using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence;

public class ApiTemplateDbContext : DbContext
{
    public ApiTemplateDbContext(DbContextOptions<ApiTemplateDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore(typeof(UserId));
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiTemplateDbContext).Assembly);
        modelBuilder.HasDefaultSchema("ApiTemplate");
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
}