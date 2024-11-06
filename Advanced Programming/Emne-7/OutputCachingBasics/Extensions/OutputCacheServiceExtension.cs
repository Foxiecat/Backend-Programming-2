namespace OutputCachingBasics.Extensions;

public static class OutputCacheServiceExtension
{
    public static void AddOutputCacheExtension(this IServiceCollection services)
    {
        services.AddOutputCache(options =>
        {
            options.AddBasePolicy(o => o.Expire(TimeSpan.FromMinutes(5)));
            
            options.AddPolicy("AuthenticatedUserCachePolicy", builder =>
            {
                builder
                    .SetVaryByHeader("Authorization")
                    .Expire(TimeSpan.FromMinutes(5));
            });
            
            options.AddPolicy("CacheForOneMinute", builder => builder.Expire(TimeSpan.FromMinutes(1)));
            
            options.AddPolicy("NoCache", builder => builder.NoCache());
        });
    }
}