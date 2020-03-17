using MySpace.Utilities.Security;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MySpace.Utilities.UnitTests.Security
{
    [Trait("安全", "RSA")]
    public class RSAUtilTest
    {
        [Fact(DisplayName = "生成公钥私钥")]
        public void GenerateKeySuccess()
        {
            var result = RSAUtil.GenerateKey();
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "生成Pkcs8Key")]
        public void GeneratePkcs8KeySuccess()
        {
            var result = RSAUtil.GenerateRSA2KeysWithPKCS8();
            Assert.NotNull(result.Key);
            Assert.NotNull(result.Value);
        }

        [Fact(DisplayName = "生成Pkcs1Key")]
        public void GeneratePkcs1KeySuccess()
        {
            var result = RSAUtil.GenerateRSA2KeysWithPKCS1();
            Assert.NotNull(result.Key);
            Assert.NotNull(result.Value);
        }
    }
}
