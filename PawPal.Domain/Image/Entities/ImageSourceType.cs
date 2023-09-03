using PawPal.Domain.Common.Enums;
using PawPal.Domain.Image.ValueObjects;
using PawPal.Domain.Models;

namespace PawPal.Domain.Image.Entities;

public class ImageSourceType : Entity<ImageSourceTypeId>
{
    private readonly List<Image> _images = new();

    public string Name { get; set; } = null!;
    public ImageSource ImageSource { get; set; }
    public IReadOnlyList<Image> Images => _images.AsReadOnly();
    
    private ImageSourceType(ImageSourceTypeId id, string name, ImageSource imageSource) : base(id)
    {
        Name = name;
        ImageSource = imageSource;
    }
    
    public static ImageSourceType Create(string name, ImageSource imageSource)
    {
        return new(ImageSourceTypeId.CreateUnique(), name, imageSource);
    }
}