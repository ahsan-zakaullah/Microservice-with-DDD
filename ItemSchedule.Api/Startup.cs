using ItemSchedule.Domain.Schedule.Repositories;
using ItemSchedule.Extensions;
using ItemSchedule.Infrastructure.DbContexts.Schedule;
using ItemSchedule.Infrastructure.Repositories.Schedule;
using ItemSchedule.Middlewares;
using ItemSchedule.Services;
using ItemSchedule.Services.Interfaces;
using Microsoft.OpenApi.Models;

namespace ItemSchedule;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(x => x.AllowEmptyInputInBodyModelBinding = true);

        // Enable Swagger   
        services.AddSwaggerGen(c =>
        {
            //c.SchemaFilter<SearchFilters>(); // Inject the request filter to assign the default values of specific model

            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Schedule", Version = "v1" });
            // To Enable authorization using Swagger (JWT)  
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme." +
                " \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
        });

        services.AddSingleton(_configuration);
        services.AddDatabase(_configuration);
        services.AddCors();
        services.AddScoped<IScheduleService, SchedulesService>();
        services.AddTransient<IScheduleRepository, ScheduleRepository>();

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IScheduleDbContext dbContext)
    {
        // Add the middleware the handle the exception at global level
        app.ConfigureExceptionHandler();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Schedule v1"));
    }

}