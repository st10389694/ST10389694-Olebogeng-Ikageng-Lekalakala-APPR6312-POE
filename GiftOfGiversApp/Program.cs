using Microsoft.EntityFrameworkCore;
using GiftOfGiversApp.Data;
using GiftOfGiversApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opts => opts.UseInMemoryDatabase("GiftOfGiversDb"));
builder.Services.AddScoped<IClaimService, ClaimService>();
var app = builder.Build();
app.MapControllers();
app.Run();
