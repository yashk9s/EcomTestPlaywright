using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.Helpers
{
    public class TestDataGenerator
    {
        public static RandomTestData Generate()
        {
            /*var faker = new Faker<RandomTestData>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Address1, f => f.Address.StreetAddress())
                .RuleFor(u => u.City, f => f.Address.City())
                .RuleFor(u => u.State, f => f.Address.State())
                .RuleFor(u => u.ZipCode, f => f.Address.ZipCode())
                .RuleFor(u => u.Country, f => f.Address.Country())
                .RuleFor(u => u.LoginName, (f, u) => $"{u.FirstName.ToLower()}.{u.LastName.ToLower()}")
                .RuleFor(u => u.Password, f => f.Internet.Password());
            return faker.Generate();*/
            /*RandomTestData rnd = new RandomTestData();
            rnd.FirstName = new Faker().Name.FirstName();
            rnd.LastName = new Faker().Name.LastName();*/

            var faker = new Faker("en_IND");

            return new RandomTestData
            {                
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Email = faker.Internet.Email(),
                Telephone = faker.Phone.PhoneNumber(),
                Address = faker.Address.StreetAddress(),
                City = faker.Address.City(),
                State = "Delhi",
                ZipCode = faker.Address.ZipCode(),
                Country = "India",                
                Password = faker.Internet.Password()
            };
        }
    }   
}