namespace GiftOfGiversApp.Models;
public class Claim { public int Id {get;set;} public string? UserId {get;set;} public int HoursWorked {get;set;} public decimal HourlyRate {get;set;} public string? Description {get;set;} public DateTime CreatedAt {get;set;} = DateTime.UtcNow; }
public record CreateClaimRequest { public int HoursWorked { get; init; } public decimal HourlyRate { get; init; } public string? Description { get; init; } }
public record ClaimDto(int Id, string? UserId, int HoursWorked, decimal HourlyRate, string? Description, DateTime CreatedAt);
