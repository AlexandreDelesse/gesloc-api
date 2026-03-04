
using GeslocApi.Application.Interfaces;
using GeslocApi.Application.Services;
using GeslocApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQLite Databse
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data source=gesloc.db"));

// Services
builder.Services.AddScoped<IPropertyService, PropertyService>();
// Define CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Activate CORS policy
app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();

