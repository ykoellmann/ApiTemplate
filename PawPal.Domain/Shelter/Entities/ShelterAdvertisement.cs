using System.ComponentModel.DataAnnotations.Schema;
using PawPal.Domain.Image.ValueObjects;
using PawPal.Domain.Models;
using PawPal.Domain.Shelter.ValueObjects;
using PawPal.Domain.Species.Entities;
using PawPal.Domain.Species.ValueObjects;

namespace PawPal.Domain.Shelter.Entities;

public class ShelterAdvertisement : Entity<ShelterAdvertisementId>
{
    private List<Image.Image> _images = new();
    private List<Chat.Chat> _chats = new();
    private List<Like.Like> _likes = new();


    public ShelterId ShelterId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Name { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }
    public string Description { get; set; } = null!;
    public SpeciesBreedId SpeciesBreedId { get; set; } = null!;
    public IReadOnlyList<Image.Image> Images => _images.AsReadOnly();
    public IReadOnlyList<Chat.Chat> Chats => _chats.AsReadOnly();
    public IReadOnlyList<Like.Like> Likes => _likes.AsReadOnly();
    
    public Shelter Shelter { get; set; } = null!;    
    public SpeciesBreed SpeciesBreed { get; set; } = null!;
    public ImageSourceTypeId ImageSourceTypeId { get; set; } = ImageSourceTypeId.Create(Guid.NewGuid());
    public ImageSourceId ImageSourceId { get; set; }
    

    

    private ShelterAdvertisement(ShelterAdvertisementId id, ShelterId shelterId, string title, string name, DateOnly dateOfBirth, string description, SpeciesBreedId speciesBreedId) : base(id)
    {
        ShelterId = shelterId;
        Title = title;
        Name = name;
        DateOfBirth = dateOfBirth;
        Description = description;
        SpeciesBreedId = speciesBreedId;
        ImageSourceId = ImageSourceId.Create(Id.Value);
    }
    
    public static ShelterAdvertisement Create(ShelterId shelterId, string title, string name, DateOnly dateOfBirth, string description, SpeciesBreedId speciesBreedId)
    {
        return new(ShelterAdvertisementId.CreateUnique(), shelterId, title, name, dateOfBirth, description, speciesBreedId);
    }
}