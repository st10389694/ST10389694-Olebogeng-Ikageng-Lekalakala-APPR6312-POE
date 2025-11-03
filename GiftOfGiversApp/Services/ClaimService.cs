using GiftOfGiversApp.Data;
using GiftOfGiversApp.Models;
using Microsoft.EntityFrameworkCore;
namespace GiftOfGiversApp.Services;
public class ClaimService : IClaimService
{
    private readonly AppDbContext _db;
    public ClaimService(AppDbContext db) => _db = db;
    public async Task<ClaimDto> CreateClaimAsync(CreateClaimRequest request, string userId)
    {
        if (request.HoursWorked <= 0) throw new ArgumentException("HoursWorked must be > 0");
        if (request.HourlyRate <= 0) throw new ArgumentException("HourlyRate must be > 0");
        var c = new Claim { UserId = userId, HoursWorked = request.HoursWorked, HourlyRate = request.HourlyRate, Description = request.Description };
        _db.Claims.Add(c);
        await _db.SaveChangesAsync();
        return new ClaimDto(c.Id, c.UserId, c.HoursWorked, c.HourlyRate, c.Description, c.CreatedAt);
    }
    public async Task<ClaimDto?> GetClaimAsync(int id) => await _db.Claims.Where(x=>x.Id==id).Select(c=> new ClaimDto(c.Id,c.UserId,c.HoursWorked,c.HourlyRate,c.Description,c.CreatedAt)).FirstOrDefaultAsync();
    public async Task<IEnumerable<ClaimDto>> GetClaimsForUserAsync(string userId) => await _db.Claims.Where(c=>c.UserId==userId).Select(c=> new ClaimDto(c.Id,c.UserId,c.HoursWorked,c.HourlyRate,c.Description,c.CreatedAt)).ToListAsync();
}
