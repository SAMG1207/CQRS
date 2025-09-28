using CQRSMediaTr.Domain;
using CQRSMediaTr.Infrastructure.Persistance;
using CQRSMediaTr.Infrastructure.Persistance.Repository.BeerRepository;
using CQRSMediaTr.Infrastructure.Persistance.Repository.BrandRepository;
using CQRSMediaTr.Infrastructure.Persistance.UnitOfWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("Database"));

builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBeerRepository, BeerRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(typeof(Program).Assembly);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Brands.Any())
    {
        context.Brands.AddRange(
            new Brand { Id = 1, Name = "Polar" },
            new Brand { Id = 2, Name = "Mahou" },
            new Brand { Id = 3, Name = "Alhambra" },
            new Brand { Id = 4, Name = "Corona" },
            new Brand { Id = 5, Name = "Heineken" }
        );
        context.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
