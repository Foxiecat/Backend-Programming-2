using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace StudentBloggAPI.Data.Health;

public class DatabaseHealthCheck(StudentBloggDbContext dbContext) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
    {
        try
        {
            if (await dbContext.Database.CanConnectAsync(cancellationToken))
                return HealthCheckResult.Healthy("Database connection is healthy");
            
            return HealthCheckResult.Unhealthy("Database connection is not healthy");
        }
        catch (Exception exception)
        {
            return HealthCheckResult.Unhealthy("Database connection failed!", exception);
        }
    }
}