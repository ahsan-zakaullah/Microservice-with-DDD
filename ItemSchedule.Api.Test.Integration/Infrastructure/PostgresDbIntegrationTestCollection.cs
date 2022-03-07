using Xunit;

namespace ItemSchedule.Api.Test.Infrastructure;

[CollectionDefinition("PostgresDB Integration Tests")]
public class PostgresDbIntegrationTestCollection : ICollectionFixture<IntegrationTestFixture>
{
}