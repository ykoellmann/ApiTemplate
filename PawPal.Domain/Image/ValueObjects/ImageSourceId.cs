using PawPal.Domain.Models;

namespace PawPal.Domain.Image.ValueObjects;

public class ImageSourceId : IdObject<ImageSourceId>
{
    protected ImageSourceId(Guid value) : base(value)
    {
    }
}