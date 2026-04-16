using Microsoft.Playwright;
using Microsoft.Win32;
using Reqnroll;
using System;
using System.Buffers.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestProject1.Configs;
using TestProject1.Pages;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TestProject1.StepDefination
{
    [Binding]
    public class SmokeTestingStepDefinitions
    {
        private IPage _page;
        private readonly ScenarioContext _scenarioContext;
        private readonly AppConfigs _appConfigs;
        private readonly HomePage _homePage;
        private readonly ProductAdd _productAdd;       
        private readonly CommonLocators _commonLocators;
        private readonly RegistrationPage _registrationPage;
        public SmokeTestingStepDefinitions(ScenarioContext scenarioContext, HomePage homePage, ProductAdd productAdd,
             IPage page, CommonLocators commonLocators, RegistrationPage registrationPage)
        {
            _page = page;
            _scenarioContext = scenarioContext;
            _homePage = homePage;
            _productAdd = productAdd;            
            _commonLocators = commonLocators;
            _registrationPage = registrationPage;
            _appConfigs = new AppConfigs();
        }

        [Given("Launching the Application")]
        public async Task GivenLaunchingTheApplication()
        {
            var url = _appConfigs.GetJsonFile("BaseUrl");
            await _page.GotoAsync(url);           
        }        

        [Given("user is on the homepage")]
        public async Task GivenUserIsOnTheHomepage()
        {
            await _homePage.VerifyHomePageHeading();
        }

        [Given("user adds a product to the cart")]
        public async Task GivenUserAddsAProductToTheCart()
        {
            await _productAdd.HoverOnMenNavbar();
            await _productAdd.ClickOnFragranceSets();
            await _productAdd.VerifyHeadingFragranceSets();
            await _productAdd.ClickOnProductOne();
            await _commonLocators.ClickOnAddToCartButton();
            await _productAdd.VerifyHeadingShoppingCart();
            await _productAdd.ClickOnCheckoutButton();
            await _productAdd.VerifyAccountLoginHeading();
            await _productAdd.ClickOnGuestCheckoutOption();
            await _commonLocators.ClickOnContinueButton();
            await _productAdd.VerifyGuestCheckoutHeading();
        }

        [Given("user navigates to the login page")]
        public async Task GivenUserNavigatesToTheLoginPage()
        {
            await _homePage.ClickOnLoginOrRegisterLink();
        }

        [When("user enters required checkout details")]
        public async Task WhenUserEntersRequiredCheckoutDetails()
        {
            await _productAdd.EnterFirstName();
            await _productAdd.EnterLastName();
            await _productAdd.EnterEmail();
            await _productAdd.EnterTelephone();
            await _productAdd.EnterAddress1();
            await _productAdd.EnterCountry();
            await _productAdd.EnterCity();
            await _productAdd.EnterPostCode();
            await _productAdd.SelectStateFromDropdown();
        }

        [When("user clicks on proceed to checkout")]
        public async Task WhenUserClicksOnProceedToCheckout()
        {
            await _commonLocators.ClickOnContinueButton();
            await _productAdd.VerifyCheckoutConfirmation();
            await _productAdd.ClickOnConfirmOrderButton();
        }

        [When("user enters valid username and password {string} {string}")]
        public async Task WhenUserEntersValidUsernameAndPassword(string username, string password)
        {
            bool isAccountLoginHeadingVisible = await _homePage.VerifyAccountLoginHeading();
            Assert.That(isAccountLoginHeadingVisible, Is.True, "Account Login heading is not visible");
            await _homePage.EnterLoginName(username);
            await _homePage.EnterPassword(password);
            await _homePage.ClickOnLoginButton();
        }

        [When("user enters keyword and category {string} {string}")]
        public async Task WhenUserEnterskeywordAndCategory(string keyword, string category)
        {
            await _homePage.FillSearchKeywordTextBox(keyword);
            await _homePage.ClickOnSearchButton();
            bool isSearchCriteriaHeadingVisible = await _homePage.VerifySearchCriteriaHeading();
            Assert.That(isSearchCriteriaHeadingVisible, Is.True, "Search Criteria heading is not visible");
            await _homePage.VerifyTextInsideKeywordTextbox(keyword);
            await _homePage.SelectCategory(category);
            await _commonLocators.ClickOnSearchButton();
        }

        [When("user fills the registration form with valid details")]
        public async Task WhenUserFillsTheRegistrationFormWithValidDetails()
        {
            await _homePage.ClickOnLoginOrRegisterLink();
            bool isRadioButtonChecked = await _registrationPage.VerifyRegisterAccountRadioButtonIsChecked();
            Assert.That(isRadioButtonChecked, Is.True, "Register Account radio button is not selected by default");
            await _commonLocators.ClickOnContinueButton();
            await _registrationPage.EnterFirstName();
            await _registrationPage.EnterLastName();
            await _registrationPage.EnterEmail();
            await _registrationPage.EnterTelephone();
            await _registrationPage.EnterAddressOne();
            await _registrationPage.EnterCity();
            await _registrationPage.SelectCountry();
            await _registrationPage.SelectState();
            await _registrationPage.EnterZipCode();
            await _registrationPage.EnterLoginName();
            await _registrationPage.EnterPassword();
            await _registrationPage.EnterConfirmPassword();
            await _registrationPage.AgreeToTerms();
            await _commonLocators.ClickOnContinueButton();            
        }


        [Then("order should be placed successfully")]
        public async Task ThenOrderShouldBePlacedSuccessfully()
        {
            await _productAdd.VerifyOrderProcessedSuccessfully();
        }

        [Then("user should be logged in successfully")]
        public async Task ThenUserShouldBeLoggedInSuccessfully()
        {
            bool isMyAccountHeadingVisible = await _homePage.VerifyMyAccountHeading();
            Assert.That(isMyAccountHeadingVisible, Is.True, "My Account heading is not visible");
        }

        [Then("Results match search keyword")]
        public async Task ThenResultsMatchSearchKeyword()
        {
            bool isSortByBoxVisible = await _homePage.VerifySortByBoxVisible();
            Assert.That(isSortByBoxVisible, Is.True, "Sort By box is not visible");
            bool isProductVisible = await _homePage.VerifyProductsVisible();
            Assert.That(isProductVisible, Is.True, "Product is not visible");
        }

        [Then("user is able to register successfully")]
        public async Task ThenUserIsAbleToRegisterSuccessfully()
        {
            var text = await _registrationPage.VerifyAccountCreatedTextIsVisible();
            Assert.That(text, Is.EqualTo(" YOUR ACCOUNT HAS BEEN CREATED!"), $"Expected 'Your Account Has Been Created!' but found '{text}'");
        }
    }
}