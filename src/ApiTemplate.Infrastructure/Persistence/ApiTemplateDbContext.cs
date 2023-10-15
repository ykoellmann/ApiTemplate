using ApiTemplate.Domain.Models;
using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;
using ApiTemplate.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace ApiTemplate.Infrastructure.Persistence;

public class ApiTemplateDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
    
    public ApiTemplateDbContext(DbContextOptions<ApiTemplateDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore(typeof(UserId));
        modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(ApiTemplateDbContext).Assembly);
        modelBuilder.HasDefaultSchema("ApiTemplate");
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<UserEntity?> Users { get; set; } = null!;
    public DbSet<RefreshTokenEntity> RefreshTokens { get; set; } = null!;
}