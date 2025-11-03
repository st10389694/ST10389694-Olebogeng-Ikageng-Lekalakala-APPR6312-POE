using Xunit;
using GiftOfGivers.Services;
using GiftOfGivers.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GiftOfGivers.Models;
using System.Linq;

namespace GiftOfGivers.Tests;

public class ClaimServiceTests
{
    private AppDbContext CreateDb()
    {
        var opts = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(opts);
    }

    [Fact]
    public async Task CreateClaimAsync_ValidRequest_Persists()
    {
        var db = CreateDb();
        var svc = new ClaimService(db);
        var req = new CreateClaimRequest { HoursWorked = 5, HourlyRate = 100m, Description = "Test" };

        var dto = await svc.CreateClaimAsync(req, "user-1");

        Assert.NotNull(dto);
        Assert.Equal(5, dto.HoursWorked);
        Assert.Equal(100m, dto.HourlyRate);
        Assert.Equal(1, db.Claims.Count());
    }

    [Fact]
    public async Task CreateClaimAsync_InvalidHours_Throws()
    {
        var db = CreateDb();
        var svc = new ClaimService(db);
        var req = new CreateClaimRequest { HoursWorked = 0, HourlyRate = 100m };

        await Assert.ThrowsAsync<System.ArgumentException>(async () =>
            await svc.CreateClaimAsync(req, "user-1"));
    }
}
