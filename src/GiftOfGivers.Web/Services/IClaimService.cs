using GiftOfGivers.Models;

namespace GiftOfGivers.Services;

public interface IClaimService
{
    Task<ClaimDto> CreateClaimAsync(CreateClaimRequest request, string userId);
    Task<ClaimDto?> GetClaimAsync(int id);
    Task<IEnumerable<ClaimDto>> GetClaimsForUserAsync(string userId);
}
