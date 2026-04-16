using Microsoft.Playwright;

namespace TestProject1.Pages
{
    public class CommonLocators(IPage _page)
    {
        private ILocator SearchButton => _page.GetByRole(AriaRole.Button, new() { Name = "Search" });
        private ILocator ContinueButton => _page.GetByRole(AriaRole.Button, new() { Name = "Continue" });
        private ILocator AddToCartButton => _page.GetByRole(AriaRole.Link, new() { Name = "Add to Cart" }); 

        public async Task ClickOnSearchButton()
        {
            await SearchButton.ClickAsync();
        }

        public async Task ClickOnContinueButton()
        {
            await ContinueButton.ClickAsync();
        }

        public async Task ClickOnAddToCartButton()
        {
            await AddToCartButton.ClickAsync();
        }
    }
}