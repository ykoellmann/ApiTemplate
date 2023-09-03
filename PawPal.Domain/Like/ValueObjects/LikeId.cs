using PawPal.Domain.Models;

namespace PawPal.Domain.Like.ValueObjects;

public class LikeId : IdObject<LikeId>
{
    private LikeId(Guid value) : base(value)
    {
    }
}