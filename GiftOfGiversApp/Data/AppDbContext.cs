using Microsoft.EntityFrameworkCore;
using GiftOfGiversApp.Models;
namespace GiftOfGiversApp.Data;
public class AppDbContext : DbContext { public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) {} public DbSet<Claim> Claims => Set<Claim>(); }
