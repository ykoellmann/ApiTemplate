using ApiTemplate.Domain.Common;
using ApiTemplate.Domain.Users;
using ApiTemplate.Domain.Users.ValueObjects;
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
                guid => new UserId(guid));
    }
}