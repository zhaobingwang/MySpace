using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MySpace.Utilities.Security
{
    /// <summary>
    /// RSA工具类
    /// </summary>
    public static class RSAUtil
    {
        /// <summary>
        /// 生产公钥和私钥
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<string, string> GenerateKey()
        {
            var rsa = RSA.Create();
            var publicKey = rsa.ToXmlString(false);
            var privateKey = rsa.ToXmlString(true);
            return new KeyValuePair<string, string>(publicKey, privateKey);
        }
    }
}
