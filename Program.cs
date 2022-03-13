
using Microsoft.EntityFrameworkCore;
using MockDbContextForUnitTesting.Api.MockDbContextForUnitTesting.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwaggerUI();
app.UseSwagger(x => x.SerializeAsV2 = true);

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProjectProjectDbContext>();
    if (db.Database.IsRelational())
    {
        db.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
