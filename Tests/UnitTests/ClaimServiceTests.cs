using Xunit;
using GiftOfGiversApp.Services;
using GiftOfGiversApp.Data;
using Microsoft.EntityFrameworkCore;
using GiftOfGiversApp.Models;
using System.Linq;
using System.Threading.Tasks;

public class ClaimServiceTests
{
    private AppDbContext CreateDb() {
        var opts = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(System.Guid.NewGuid().ToString()).Options;
        return new AppDbContext(opts);
    }

    [Fact]
    public async Task CreateClaim_Valid_Persists() {
        var db = CreateDb();
        var svc = new ClaimService(db);
        var dto = await svc.CreateClaimAsync(new CreateClaimRequest { HoursWorked = 4, HourlyRate = 120m, Description = "unit test" }, "u1");
        Assert.NotNull(dto);
        Assert.Equal(1, db.Claims.Count());
    }

    [Fact]
    public async Task CreateClaim_InvalidHours_Throws() {
        var db = CreateDb();
        var svc = new ClaimService(db);
        await Assert.ThrowsAsync<System.ArgumentException>(async ()=> await svc.CreateClaimAsync(new CreateClaimRequest{ HoursWorked=0, HourlyRate=100m }, "u1"));
    }
}
