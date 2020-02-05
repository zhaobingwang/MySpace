using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MySpace.SDK.IntegrationTests
{
    public class BaseTest<T> where T : class
    {
        protected IConfigurationRoot Configuration;
        public BaseTest()
        {
            var assembly = typeof(T).GetTypeInfo().Assembly;
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets(assembly)
                .Build();
        }
    }
}
