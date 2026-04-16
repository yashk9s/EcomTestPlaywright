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
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _browserContext;
        private IPage _page;        
        private ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer container, ScenarioContext scenarioContext)
        {
            _container = container;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public async Task FirstBeforeScenario()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            
            if (_browser == null)
            {
                throw new Exception("Browser is NULL – BeforeTestRun did not run");
            }

            _browserContext = await _browser.NewContextAsync();
            _page = await _browserContext.NewPageAsync();           
            _page.SetDefaultTimeout(30000);
             await _page.SetViewportSizeAsync(1920, 1080);
            _container.RegisterInstanceAs(_playwright);
            _container.RegisterInstanceAs(_browser);
            _container.RegisterInstanceAs(_browserContext);
            _container.RegisterInstanceAs(_page);  
        }

        [AfterScenario]
        public async Task AfterScenario()
        {         
            await _browser.CloseAsync();
        }      
    }
}