using Microsoft.EntityFrameworkCore;
using SyncService.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>();
    
builder.Services.AddOpenApi();
builder.Services.AddDbContext<SyncDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
