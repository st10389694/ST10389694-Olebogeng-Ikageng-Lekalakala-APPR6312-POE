using GiftOfGiversApp.Models;
namespace GiftOfGiversApp.Services;
public interface IClaimService { Task<ClaimDto> CreateClaimAsync(CreateClaimRequest request, string userId); Task<ClaimDto?> GetClaimAsync(int id); Task<IEnumerable<ClaimDto>> GetClaimsForUserAsync(string userId); }
