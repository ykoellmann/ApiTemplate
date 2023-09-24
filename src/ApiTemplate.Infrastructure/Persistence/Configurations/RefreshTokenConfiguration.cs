using ApiTemplate.Domain.User;
using ApiTemplate.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiTemplate.Infrastructure.Persistence.Configurations;

public class RefreshTokenConfiguration : BaseConfiguration<RefreshToken, RefreshTokenId>
{
    public override void ConfigureEntity(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens");

        builder.Property(rt => rt.UserId)
            .HasConversion(userId => userId.Value,
                guid => UserId.Create(guid));
    }
}