using PawPal.Domain.Models;

namespace PawPal.Domain.Image.ValueObjects;

public class ImageSourceTypeId : IdObject<ImageSourceTypeId>
{
    private ImageSourceTypeId(Guid value) : base(value)
    {
    }
}