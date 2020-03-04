﻿using MySpace.Utilities.Security;
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
    }
}
