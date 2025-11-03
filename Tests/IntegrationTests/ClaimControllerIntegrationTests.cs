using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using GiftOfGiversApp.Models;
using System.Threading.Tasks;

public class ClaimControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    public ClaimControllerIntegrationTests(WebApplicationFactory<Program> factory) { _client = factory.CreateClient(); }
    [Fact]
    public async Task PostAndGetClaim_EndToEnd() {
        var req = new CreateClaimRequest{ HoursWorked=2, HourlyRate=100m, Description="int test" };
        var content = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8, "application/json");
        var post = await _client.PostAsync("/api/claim", content);
        post.EnsureSuccessStatusCode();
        var created = JsonSerializer.Deserialize<ClaimDto>(await post.Content.ReadAsStringAsync(), new JsonSerializerOptions{PropertyNameCaseInsensitive=true});
        var get = await _client.GetAsync($"/api/claim/{created.Id}");
        get.EnsureSuccessStatusCode();
    }
}
