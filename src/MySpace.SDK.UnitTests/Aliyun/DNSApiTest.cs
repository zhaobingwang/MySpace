using Microsoft.Extensions.Configuration;
using MySpace.SDK.Aliyun;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace MySpace.SDK.UnitTests.Aliyun
{
    public class DNSApiTest
    {
        private string accessKeyId;
        private string accessSecret;
        public DNSApiTest()
        {
            var assembly = typeof(DNSApiTest).GetTypeInfo().Assembly;
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets(assembly)
                .Build();
            accessKeyId = config.GetSection("Aliyun:DNS:AccessKeyId").Value;
            accessSecret = config.GetSection("Aliyun:DNS:AccessSecret").Value;
        }
        [Fact]
        public void GetDomainRecordsShouldSuccess()
        {
            DNSApi dnsApi = new DNSApi(accessKeyId, accessSecret);
            var result = dnsApi.GetDomainRecords("cstree.cn", 1);
            Assert.NotNull(result);
        }
    }
}
