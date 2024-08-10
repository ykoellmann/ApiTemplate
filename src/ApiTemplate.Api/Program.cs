using ApiTemplate.Api;
using ApiTemplate.Application;
using ApiTemplate.Infrastructure;
using Hangfire;
using Hangfire.Dashboard;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.UseRateLimiter();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.UseHangfireDashboard("/hangfire", new DashboardOptions
    {
        Authorization = new IDashboardAuthorizationFilter[]{ new DashboardAuthorizationFilter() }
    });
    app.Run();
}