using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.Helpers;

namespace TestProject1.Pages
{
    public class RegistrationPage(IPage _page, ScenarioContext _scenarioContext)
    {
        private ILocator RegisterAccountRadioButton => _page.Locator("input#accountFrm_accountregister[value='register']");
        private ILocator FirstNameBox => _page.Locator("#AccountFrm_firstname");
        private ILocator LastNameBox => _page.Locator("#AccountFrm_lastname");
        private ILocator EmailBox => _page.Locator("#AccountFrm_email");
        private ILocator TelephoneBox => _page.Locator("#AccountFrm_telephone");
        private ILocator Address1 => _page.Locator("#AccountFrm_address_1");
        private ILocator CityBox => _page.Locator("#AccountFrm_city");
        private ILocator StateBox => _page.Locator("#AccountFrm_zone_id");
        private ILocator ZipCodeBox => _page.Locator("#AccountFrm_postcode");
        private ILocator CountryBox => _page.Locator("#AccountFrm_country_id");
        private ILocator LoginNameBox => _page.Locator("#AccountFrm_loginname");
        private ILocator PasswordBox => _page.Locator("#AccountFrm_password");
        private ILocator ConfirmPasswordBox => _page.Locator("#AccountFrm_confirm");
        private ILocator FormAgreeBox => _page.Locator("#AccountFrm_agree");
        private ILocator AccountCreatedText => _page.Locator("//span[@class='maintext']");        

        public async Task<string> VerifyAccountCreatedTextIsVisible()
        {
            await AccountCreatedText.IsVisibleAsync();
            var text = await AccountCreatedText.InnerTextAsync();
            return text;
        }

        public async Task EnterFirstName()
        {
            var testData = TestDataGenerator.Generate();
            await FirstNameBox.FillAsync(testData.FirstName);
            _scenarioContext.Set(testData.FirstName, "FirstName");
            Console.WriteLine($"First name entered: {testData.FirstName}");
        }

        public async Task EnterLastName()
        {
            var testData = TestDataGenerator.Generate();
            await LastNameBox.FillAsync(testData.LastName);
            _scenarioContext.Set(testData.LastName, "LastName");
            Console.WriteLine($"Last name entered: {testData.LastName}");
        }

        public async Task EnterEmail()
        {
            var testData = TestDataGenerator.Generate();
            await EmailBox.FillAsync(testData.Email);
            Console.WriteLine($"Email entered: {testData.Email}");
        }

        public async Task EnterTelephone()
        {
            var testData = TestDataGenerator.Generate();
            await TelephoneBox.FillAsync(testData.Telephone);
            Console.WriteLine($"Telephone number entered: {testData.Telephone}");
        }

        public async Task EnterAddressOne()
        {
            var testData = TestDataGenerator.Generate();
            await Address1.FillAsync(testData.Address);
            Console.WriteLine($"Address entered: {testData.Address}");
        }

        public async Task EnterCity()
        {
            var testData = TestDataGenerator.Generate();
            await CityBox.FillAsync(testData.City);
            Console.WriteLine($"City entered: {testData.City}");
        }

        public async Task SelectState()
        {                                             
            await StateBox.SelectOptionAsync(new SelectOptionValue { Label = "Delhi" });
        }

        public async Task EnterZipCode()
        {
            var testData = TestDataGenerator.Generate();
            await ZipCodeBox.FillAsync(testData.ZipCode);
            Console.WriteLine($"Zip code entered: {testData.ZipCode}");
        }

        public async Task SelectCountry()
        {
            var testData = TestDataGenerator.Generate();
            await CountryBox.SelectOptionAsync(new SelectOptionValue
            {
                Label = testData.Country
            });
            Console.WriteLine($"Selected country: {testData.Country}");
        }

        public async Task EnterLoginName()
        {
            var firstName = _scenarioContext.Get<string>("FirstName");
            var lastName = _scenarioContext.Get<string>("LastName");
            await LoginNameBox.FillAsync(firstName + lastName);
            Console.WriteLine($"Login name entered: {firstName + lastName}");
        }

        public async Task EnterPassword()
        {
            var testData = TestDataGenerator.Generate();
            _scenarioContext.Set(testData.Password, "Password");
            await PasswordBox.FillAsync(testData.Password);
            Console.WriteLine($"Password entered: {testData.Password}");
        }

        public async Task EnterConfirmPassword()
        {
            var confirmPassword = _scenarioContext.Get<string>("Password");
            await ConfirmPasswordBox.FillAsync(confirmPassword);
        }

        public async Task AgreeToTerms()
        {
            await FormAgreeBox.CheckAsync();
        }

        public async Task<bool> VerifyRegisterAccountRadioButtonIsChecked()
        {
            return await RegisterAccountRadioButton.IsCheckedAsync();
        }
    }
}
