using PawPal.Domain.Common;
using PawPal.Domain.Common.Enums;
using PawPal.Domain.Image.Entities;
using PawPal.Domain.Image.ValueObjects;
using PawPal.Domain.Models;

namespace PawPal.Domain.Image;

public class Image : AggregateRoot<ImageId>
{
    public string FileName { get; set; } = null!;
    public ContentType ContentType { get; set; }
    public byte[] Data { get; set; } = null!;
    public ImageSourceTypeId ImageSourceTypeId { get; set; }
    public ImageSourceId ImageSourceId { get; set; }
    
    public object Source { get; set; }
    public ImageSourceType ImageSourceType { get; set; } = null!;
    
    private Image(ImageId id, string fileName, ContentType contentType, byte[] data, ImageSourceTypeId imageSourceTypeId, ImageSourceId imageSourceId) : base(id)
    {
        FileName = fileName;
        ContentType = contentType;
        Data = data;
        ImageSourceTypeId = imageSourceTypeId;
        ImageSourceId = imageSourceId;
    }
    
    public static Image Create(string fileName, ContentType contentType, byte[] data, ImageSourceTypeId imageSourceTypeId, ImageSourceId imageSourceId)
    {
        return new(ImageId.CreateUnique(), fileName, contentType, data, imageSourceTypeId, imageSourceId);
    }
}