using Microsoft.EntityFrameworkCore;
using server.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Add DbContext using SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") 
        ?? "Data Source=game.db"));

// 2. Add Controller support for API routes
builder.Services.AddControllers();

// 3. Add API documentation & OpenAPI tools
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 4. Map API Controller endpoints
app.MapControllers();

app.Run();