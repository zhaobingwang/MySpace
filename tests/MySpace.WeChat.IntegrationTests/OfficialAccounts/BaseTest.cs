using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;
using Xunit;

namespace MySpace.WeChat.IntegrationTests.OfficialAccounts
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
