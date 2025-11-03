using NUnit.Framework;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace UITests;
public class ClaimsUiTests
{
    private IPlaywright _pw;
    private IBrowser _browser;
    [SetUp]
    public async Task Setup() { _pw = await Playwright.CreateAsync(); _browser = await _pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions{ Headless=true }); }
    [TearDown]
    public async Task Teardown() { await _browser.CloseAsync(); _pw.Dispose(); }
    [Test]
    public async Task HomePageLoads() {
        var page = await _browser.NewPageAsync();
        await page.GotoAsync("http://localhost:5000");
        var title = await page.TitleAsync();
        Assert.IsTrue(string.IsNullOrEmpty(title) || title.Contains("GiftOfGivers"));
    }
}
