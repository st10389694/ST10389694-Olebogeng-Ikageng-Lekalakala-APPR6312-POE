using Xunit;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using GiftOfGivers.Models;

namespace GiftOfGivers.Tests;

public class ClaimControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ClaimControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostAndGetClaim_EndToEnd()
    {
        var req = new CreateClaimRequest { HoursWorked = 3, HourlyRate = 150m, Description = "Integration test" };
        var content = new StringContent(JsonSerializer.Serialize(req), Encoding.UTF8, "application/json");
        var postResp = await _client.PostAsync("/api/claim", content);
        postResp.EnsureSuccessStatusCode();
        var created = JsonSerializer.Deserialize<ClaimDto>(await postResp.Content.ReadAsStringAsync(), new JsonSerializerOptions{PropertyNameCaseInsensitive=true});
        Assert.NotNull(created);
        Assert.Equal(3, created.HoursWorked);

        var getResp = await _client.GetAsync($"/api/claim/{created.Id}");
        getResp.EnsureSuccessStatusCode();
        var got = JsonSerializer.Deserialize<ClaimDto>(await getResp.Content.ReadAsStringAsync(), new JsonSerializerOptions{PropertyNameCaseInsensitive=true});
        Assert.Equal(created.Id, got.Id);
    }

    [Fact]
    public async Task GetAll_ReturnsList()
    {
        var resp = await _client.GetAsync("/api/claim");
        resp.EnsureSuccessStatusCode();
    }
}
