using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins(
    "https://localhost:4200",
    "http://localhost:4200"));

app.MapControllers();

app.Run();
