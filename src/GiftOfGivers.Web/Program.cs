using Microsoft.EntityFrameworkCore;
using GiftOfGivers.Data;
using GiftOfGivers.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("GiftOfGiversDb"));

builder.Services.AddScoped<IClaimService, ClaimService>();

var app = builder.Build();

app.MapControllers();

app.Run();
