using ItemSchedule.Infrastructure.DbContexts;

namespace ItemSchedule.Services;

public abstract class ServiceBase<TDbContext> where TDbContext : IDbContext
{
    protected TDbContext DbContext { get; }

    protected ServiceBase(TDbContext dbContext)
    {
        DbContext = dbContext;
    }
}