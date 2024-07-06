namespace ApiTemplate.Infrastructure.Persistence.Repositories;

public class CacheKey<TEntity>
{
    public CacheKey(string usage)
    {
        Usage = usage;
        Value = string.Empty;
    }

    public CacheKey(string usage, string value)
    {
        Usage = usage;
        Value = value;
    }

    public CacheKey(string usage, string dto, string value)
    {
        Usage = usage;
        Value = value;
        Dto = dto;
    }

    private string Usage { get; }
    private string? Dto { get; }
    private string? Value { get; }

    public static implicit operator string(CacheKey<TEntity> cacheKey)
    {
        return cacheKey.ToString();
    }

    public override string ToString()
    {
        if (Value is null)
            return $"{typeof(TEntity).Name}:{Usage}";

        return Dto is null
            ? $"{typeof(TEntity).Name}:{Usage}:{Value}"
            : $"{typeof(TEntity).Name}:{Dto}:{Usage}:{Value}";
    }
}