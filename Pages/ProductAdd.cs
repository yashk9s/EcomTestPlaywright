using Microsoft.Playwright;
using System.Diagnostics;
using TestProject1.Helpers;

namespace TestProject1.Pages
{
    public class ProductAdd(IPage _page)
    {
        private ILocator MenNavbarLink => _page.GetByRole(AriaRole.Link, new() { Name = "MEN" }).First; 
        private ILocator FragranceSetsNavbarLink => _page.GetByRole(AriaRole.Link, new() { Name = "Fragrance Sets" });
        private ILocator FragranceSetsHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Fragrance Sets" });
        private ILocator ProductOne => _page.GetByRole(AriaRole.Link, new() { Name = "Armani Code after shave balm" });         
        private ILocator ShoppingCartHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Shopping Cart" }); 
        private ILocator ConfirmOrderButton => _page.GetByRole(AriaRole.Button, new() { Name = "Confirm Order" });
        private ILocator CheckoutButton => _page.GetByRole(AriaRole.Link, new() { Name = "Checkout" }).Last;
        private ILocator AccountLoginHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Account Login" });
        private ILocator GuestCheckoutOption => _page.GetByRole(AriaRole.Radio, new() { Name = "Guest Checkout" });       
        private ILocator GuestCheckoutHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Guest Checkout - Step 1" });
        private ILocator FirstName => _page.Locator("input#guestFrm_firstname");
        private ILocator LastName => _page.Locator("input#guestFrm_lastname");
        private ILocator Email => _page.Locator("input#guestFrm_email");
        private ILocator Telephone => _page.Locator("input#guestFrm_telephone");
        private ILocator Address1 => _page.Locator("input#guestFrm_address_1");
        private ILocator City => _page.Locator("input#guestFrm_city");
        private ILocator PostCode => _page.Locator("input#guestFrm_postcode");
        private ILocator StateDropdown => _page.Locator("select#guestFrm_zone_id");
        private ILocator StateCount => _page.Locator("//select[@id='guestFrm_zone_id']/option");
        private ILocator Country => _page.Locator("#guestFrm_country_id.form-control");
        private ILocator CheckoutConfirmationHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Checkout Confirmation" });
        private ILocator OrderProcessedHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Your Order Has Been Processed!" });
        private ILocator FirstFeatureProduct => _page.Locator("div#block_frame_featured_1769").Locator("a.productcart[data-id='50']");


        public async Task ClickOnFirstFeatureProduct()
        {
            await FirstFeatureProduct.ClickAsync();
        }

        public async Task HoverOnMenNavbar()
        {
            await MenNavbarLink.HoverAsync();   
        }

        public async Task ClickOnFragranceSets()
        {
            await FragranceSetsNavbarLink.ClickAsync();
        }

        public async Task VerifyHeadingFragranceSets()
        {
            await FragranceSetsHeading.IsVisibleAsync();
        }

        public async Task ClickOnProductOne()
        {
            await ProductOne.ClickAsync();
        }        

        public async Task VerifyHeadingShoppingCart()
        {
            await ShoppingCartHeading.IsVisibleAsync();
            
        }

        public async Task ClickOnCheckoutButton()
        {
            await CheckoutButton.ClickAsync();
        }

        public async Task ClickOnConfirmOrderButton()
        {
            await ConfirmOrderButton.ClickAsync();
        }

        public async Task VerifyAccountLoginHeading()
        {
            await AccountLoginHeading.IsVisibleAsync();

        }

        public async Task VerifyGuestCheckoutHeading()
        {
            await GuestCheckoutHeading.IsVisibleAsync();
        }

        public async Task ClickOnGuestCheckoutOption()
        {
            await GuestCheckoutOption.CheckAsync();
        }        

        public async Task EnterFirstName()
        {
            var testData = TestDataGenerator.Generate();
            await FirstName.FillAsync(testData.FirstName);
        }

        public async Task EnterLastName()
        {
            var testData = TestDataGenerator.Generate();
            await LastName.FillAsync(testData.LastName);
        }

        public async Task EnterEmail()
        {
            var testData = TestDataGenerator.Generate();
            await Email.FillAsync(testData.Email);
        }

        public async Task EnterTelephone()
        {
            var testData = TestDataGenerator.Generate();
            await Telephone.FillAsync(testData.Telephone);
        }

        public async Task EnterAddress1()
        {
            var testData = TestDataGenerator.Generate();
            await Address1.FillAsync(testData.Address);
        }

        public async Task EnterCountry()
        {
            var testData = TestDataGenerator.Generate();
            await Country.SelectOptionAsync(testData.Country);
        }

        public async Task EnterCity()
        {
            var testData = TestDataGenerator.Generate();
            await City.FillAsync(testData.City);
        }

        public async Task EnterPostCode()
        {
            var testData = TestDataGenerator.Generate();
            await PostCode.FillAsync(testData.ZipCode);
        }

        public async Task SelectStateFromDropdown()
        {
            await StateDropdown.SelectOptionAsync(new SelectOptionValue { Label = "Delhi" });
        }

        public async Task VerifyCheckoutConfirmation()
        {
            await CheckoutConfirmationHeading.IsVisibleAsync();
        }

        public async Task VerifyOrderProcessedSuccessfully()
        {
            await OrderProcessedHeading.IsVisibleAsync();
        }
    }
}