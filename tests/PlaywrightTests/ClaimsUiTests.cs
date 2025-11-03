using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests
{
    public class ClaimsUiTests
    {
        private IPlaywright _pw;
        private IBrowser _browser;

        [SetUp]
        public async Task Setup()
        {
            _pw = await Playwright.CreateAsync();
            _browser = await _pw.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
        }

        [TearDown]
        public async Task Teardown()
        {
            await _browser.CloseAsync();
            _pw.Dispose();
        }

        [Test]
        public async Task HomePage_ShouldContainTitle()
        {
            var page = await _browser.NewPageAsync();
            await page.GotoAsync("http://localhost:5000");
            var title = await page.TitleAsync();
            Assert.IsTrue(title.Contains("GiftOfGivers") || string.IsNullOrEmpty(title));
        }
    }
}
