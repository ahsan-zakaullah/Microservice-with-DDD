using System;
using System.Net.Http;
using ItemSchedule.Infrastructure.DbContexts.Schedule;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ItemSchedule.Api.Test.Infrastructure;

public class IntegrationTestFixture: IDisposable
{
    public readonly IScheduleDbContext? DbContext;
    private readonly WebApplicationFactory<Startup> _factory;

    public IntegrationTestFixture()
    {
        _factory = new CustomWebApplicationFactory<Startup>();
        DbContext = _factory.Services.GetService(typeof(IScheduleDbContext)) as IScheduleDbContext;
    }
    public void Dispose()
    {
        DbContext?.Dispose();
        _factory.Dispose();
    }

    public HttpClient HttpClient => _factory.CreateClient();
}