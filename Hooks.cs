using Reqnroll;
using Reqnroll.BoDi;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TestProject1
{
    [Binding]
    public class Hooks
    {
        private IObjectContainer _container;
        private static IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _browserContext;
        private IPage _page;
        private ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
             _container = container;
             _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static async Task BeforeTestRun()
        {
            _playwright = await Playwright.CreateAsync();
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });

            if (_browser == null)
            {
                throw new Exception("Browser is NULL – BeforeTestRun did not run");
            }
            _browserContext = await _browser.NewContextAsync();
            _page = await _browserContext.NewPageAsync();
            _page.SetDefaultTimeout(15000);
            await _page.SetViewportSizeAsync(1920, 1080);
            _container.RegisterInstanceAs(_playwright);
            _container.RegisterInstanceAs(_browser);
            _container.RegisterInstanceAs(_browserContext);
            _container.RegisterInstanceAs(_page);
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
                Directory.CreateDirectory(folderPath);               
                var screenshotPath = Path.Combine(folderPath,$"{_scenarioContext.ScenarioInfo.Title}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                await _page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath, FullPage = true });
                Console.WriteLine($"Screenshot taken: {screenshotPath}");
            }

            if (_browserContext != null)
            {
                await _browserContext.CloseAsync();
            }
        }
    }
}