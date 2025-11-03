using Microsoft.EntityFrameworkCore;
using GiftOfGivers.Models;

namespace GiftOfGivers.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }
    public DbSet<Claim> Claims => Set<Claim>();
}
