using System.ComponentModel.DataAnnotations.Schema;
using PawPal.Domain.Common;
using PawPal.Domain.Image.ValueObjects;
using PawPal.Domain.Models;
using PawPal.Domain.User.ValueObjects;

namespace PawPal.Domain.User;

public class User : Account<UserId>
{
    private readonly List<Image.Image> _images = new();
    private readonly List<Like.Like> _likes = new();
    private readonly List<Preference.Preference> _preferences = new();
    private readonly List<Chat.Chat> _chats = new();

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public IReadOnlyList<Image.Image> Images => _images.AsReadOnly();
    public IReadOnlyList<Like.Like> Likes => _likes.AsReadOnly();
    public IReadOnlyList<Preference.Preference> Preferences => _preferences.AsReadOnly();
    public IReadOnlyList<Chat.Chat> Chats => _chats.AsReadOnly();
    public ImageSourceTypeId ImageSourceTypeId { get; set; } = ImageSourceTypeId.Create(Guid.NewGuid());
    public ImageSourceId ImageSourceId { get; set; }
    [NotMapped]
    public override UserId CreatedBy { get; set; }
    [NotMapped]
    public override User CreatedByUser { get; set; }
    [NotMapped]
    public override UserId UpdatedBy { get; set; }
    [NotMapped]
    public override User UpdatedByUser { get; set; }

    private User(UserId id, string firstName, string lastName, string email, string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        ImageSourceId = ImageSourceId.Create(Id.Value);
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(UserId.CreateUnique(), firstName, lastName, email, password);
    }
}