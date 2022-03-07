using ItemSchedule.Domain.Common.ErrorLogging;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace ItemSchedule.Middlewares
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                // Use the Run() request delegate here as terminal middleware
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";


                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                      // TODO: we can log the exception detail here.

                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. Please contact the admin!"
                        }.ToString());
                    }
                });
            });
        }
    }
}
