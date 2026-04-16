using Microsoft.Extensions.Configuration;
using Microsoft.Testing.Platform.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.Configs
{
    public class AppConfigs
    {
        private IConfigurationRoot _configuration;

        public AppConfigs()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Configs/AppSettings.json", optional: false, reloadOnChange: true);            

            _configuration = builder.Build();
        }
        public string GetJsonFile(string key) 
        {           
            return _configuration[key];
        }  
    }
}