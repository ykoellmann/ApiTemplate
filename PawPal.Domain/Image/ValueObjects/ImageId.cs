using PawPal.Domain.Models;

namespace PawPal.Domain.Image.ValueObjects;

public class ImageId : IdObject<ImageId>
{
    private ImageId(Guid value) : base(value)
    {
    }
}