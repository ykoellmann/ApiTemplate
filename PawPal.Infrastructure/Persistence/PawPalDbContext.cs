using Microsoft.EntityFrameworkCore;
using PawPal.Domain.Image;
using PawPal.Domain.Image.Entities;
using PawPal.Domain.Like;
using PawPal.Domain.Preference;
using PawPal.Domain.Preference.Entities;
using PawPal.Domain.Shelter;
using PawPal.Domain.Shelter.Entities;
using PawPal.Domain.Species;
using PawPal.Domain.Species.Entities;
using PawPal.Domain.User;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Infrastructure.Persistence;

public class PawPalDbContext : DbContext
{
    public PawPalDbContext(DbContextOptions<PawPalDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore(typeof(UserId));
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PawPalDbContext).Assembly);
        modelBuilder.HasDefaultSchema("PawPal");
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Shelter> Shelters { get; set; } = null!;
    public DbSet<ShelterAdvertisement> SheltersAdvertisements { get; set; } = null!;
    public DbSet<Species> Species { get; set; } = null!;
    public DbSet<SpeciesBreed> SpeciesBreeds { get; set; } = null!;
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Preference> Preferences { get; set; } = null!;
    public DbSet<PreferenceSourceType> PreferenceSourceTypes { get; set; } = null!;
    
    public DbSet<Like> Likes { get; set; } = null!;

    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<ImageSourceType> ImageSourceTypes { get; set; } = null!;
}