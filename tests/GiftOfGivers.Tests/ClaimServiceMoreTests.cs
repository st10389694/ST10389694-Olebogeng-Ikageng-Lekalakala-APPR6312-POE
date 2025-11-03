using Xunit;
using GiftOfGivers.Data;
using Microsoft.EntityFrameworkCore;
using GiftOfGivers.Services;
using GiftOfGivers.Models;
using System.Threading.Tasks;
using System.Linq;

namespace GiftOfGivers.Tests;

public class ClaimServiceMoreTests
{
    private AppDbContext CreateDb()
    {
        var opts = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(opts);
    }

    [Fact]
    public async Task GetClaimAsync_NonExisting_ReturnsNull()
    {
        var db = CreateDb();
        var svc = new ClaimService(db);
        var c = await svc.GetClaimAsync(9999);
        Assert.Null(c);
    }

    [Fact]
    public async Task GetClaimsForUserAsync_ReturnsOnlyUserClaims()
    {
        var db = CreateDb();
        db.Claims.Add(new Claim { UserId = "user-a", HoursWorked = 1, HourlyRate = 10m });
        db.Claims.Add(new Claim { UserId = "user-b", HoursWorked = 2, HourlyRate = 20m });
        await db.SaveChangesAsync();

        var svc = new ClaimService(db);
        var list = (await svc.GetClaimsForUserAsync("user-a")).ToList();
        Assert.Single(list);
        Assert.Equal("user-a", list[0].UserId);
    }
}
