using Microsoft.Playwright;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;

namespace TestProject1.Pages
{
    public class HomePage(IPage _page)
    {
        private ILocator FastShippingHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Fast shipping" }); //home page heading
        private ILocator LoginOrRegisterLink => _page.GetByRole(AriaRole.Link, new() { Name = "Login or register" }); //Login Link
        private ILocator AccountLoginHeading => _page.GetByText("Account Login", new() { Exact = true });
        private ILocator LoginNameTextBox => _page.Locator("#loginFrm_loginname");
        private ILocator PasswordTextBox => _page.Locator("#loginFrm_password");
        private ILocator LoginButton => _page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        private ILocator MyAccountHeading => _page.Locator(".heading1").GetByText("My Account", new() { Exact = true });
        private ILocator SearchKeywordTextBox => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Keywords" });
        private ILocator SearchButton => _page.Locator(".button-in-search");
        private ILocator SearchCriteriaHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Search Criteria", Exact = true });
        private ILocator KeywordTextbox => _page.Locator("input#keyword");
        private ILocator CategoryBox => _page.Locator("select#category_id");
        private ILocator SortByBox => _page.Locator("div.sorting.well").First;
        private ILocator ProductsList => _page.Locator("div.thumbnails.grid.row.list-inline");

        public async Task<bool> VerifyProductsVisible()
        {
            return await ProductsList.IsVisibleAsync();
        }

        public async Task<bool> VerifySortByBoxVisible()
        {
            return await SortByBox.IsVisibleAsync();
        }

        public async Task VerifyTextInsideKeywordTextbox(string keyword)
        {          
            await Assertions.Expect(KeywordTextbox).ToHaveAttributeAsync("value", keyword);
        }

        public async Task SelectCategory(string category)
        {
            await CategoryBox.SelectOptionAsync(new SelectOptionValue { Value = category });
        }

        public async Task ClickOnSearchButton()
        {
            await SearchButton.ClickAsync();
        }

        public async Task FillSearchKeywordTextBox(string Keyword)
        {
            await SearchKeywordTextBox.FillAsync(Keyword);
        }

        public async Task<bool> VerifySearchCriteriaHeading()
        {
            var isVisible = await SearchCriteriaHeading.IsVisibleAsync();
            return isVisible;
        }

        public async Task VerifyHomePageHeading()
        {
            await FastShippingHeading.IsVisibleAsync();
        }

        public async Task ClickOnLoginOrRegisterLink()
        {
            await LoginOrRegisterLink.ClickAsync();
        }

        public async Task<bool> VerifyAccountLoginHeading()
        {
            var isVisible = await AccountLoginHeading.IsVisibleAsync();
            return isVisible;
        }

        public async Task EnterLoginName(string username)
        {
            await LoginNameTextBox.FillAsync(username);
        }

        public async Task EnterPassword(string password)
        {
            await PasswordTextBox.FillAsync(password);
        }

        public async Task ClickOnLoginButton()
        {
            await LoginButton.ClickAsync();
        }

        public async Task<bool> VerifyMyAccountHeading()
        {
            var isVisible = await MyAccountHeading.IsVisibleAsync();
            return isVisible;
        }        
    }
}