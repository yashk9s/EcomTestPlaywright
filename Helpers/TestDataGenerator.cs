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