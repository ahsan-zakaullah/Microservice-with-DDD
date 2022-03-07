using ItemSchedule.Api.Test.Utilities;
using ItemSchedule.Infrastructure.DbContexts.Schedule;
using Xunit;
using Xunit.Abstractions;

namespace ItemSchedule.Api.Test.Infrastructure;

[Collection("PostgresDB Integration Tests")]
public class IntegrationTestBase: IClassFixture<IntegrationTestFixture>
{
    protected ITestOutputHelper Output { get; }
    protected IScheduleDbContext? DbContext { get; }

    private IntegrationTestFixture _fixture;
    protected IntegrationTestBase(IntegrationTestFixture integrationTestFixture, ITestOutputHelper output)
    {
        Output = output;
        DbContext = integrationTestFixture.DbContext;
        _fixture = integrationTestFixture;

        if (DbContext != null)
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Database.EnsureCreated();
        }
    }

    public RequestBuilder NewRequest => new RequestBuilder(_fixture.HttpClient);
}