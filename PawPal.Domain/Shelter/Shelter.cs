using System.ComponentModel.DataAnnotations.Schema;
using PawPal.Domain.Common;
using PawPal.Domain.Image.ValueObjects;
using PawPal.Domain.Shelter.Entities;
using PawPal.Domain.Shelter.ValueObjects;

namespace PawPal.Domain.Shelter;

public class Shelter : Account<ShelterId>
{
    private readonly List<ShelterAdvertisement> _advertisements = new();
    private readonly List<Image.Image> _images = new();
    private readonly List<Chat.Chat> _chats = new();


    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Website { get; set; }
    public IReadOnlyList<ShelterAdvertisement> Advertisements => _advertisements.AsReadOnly();
    public IReadOnlyList<Image.Image> Images => _images.AsReadOnly();
    public IReadOnlyList<Chat.Chat> Chats => _chats.AsReadOnly();
    public ImageSourceTypeId ImageSourceTypeId { get; set; } = ImageSourceTypeId.Create(Guid.NewGuid());
    [NotMapped]
    public ImageSourceId ImageSourceId { get; set; }

    private Shelter(ShelterId id, string name, string address, string city, string zipCode, string phoneNumber, string? website) : base(id)
    {
        Name = name;
        Address = address;
        City = city;
        ZipCode = zipCode;
        PhoneNumber = phoneNumber;
        Website = website;
        ImageSourceId = ImageSourceId.Create(Id.Value);
    }
    
    public static Shelter Create(string name, string address, string city, string zipCode, string phoneNumber, string? website)
    {
        return new Shelter(ShelterId.CreateUnique(), name, address, city, zipCode, phoneNumber, website);
    }   
}