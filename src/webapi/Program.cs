var appName = "miniapi-webapi";

var builder = WebApplication.CreateBuilder(args);

builder.AddCommonService();

builder.AddConfigurationService();

builder.AddDbContextService(builder.Configuration.GetConnectionString("DbConnect"));

builder.AddGraphqlService();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQLVoyager();
    // endpoints.MapControllers();
});

app.UseGraphqlUI();

/// <summary>
/// ����ʵ������
/// </summary>
using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        await SeedData.SeedAsync(scopedProvider);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

try
{
    app.Logger.LogInformation("Starting web host ({ApplicationName})...", appName);
    app.Run();
}
catch (Exception ex)
{
    app.Logger.LogCritical(ex, "Host terminated unexpectedly ({ApplicationName})...", appName);
}
finally
{
    Serilog.Log.CloseAndFlush();
}

