using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// 生成RSA2密钥(PKCS1)
        /// 返回值中Key为公钥，Value为私钥
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<string, string> GenerateRSA2KeysWithPKCS1()
        {
            IAsymmetricCipherKeyPairGenerator keyPairGenerator = GeneratorUtilities.GetKeyPairGenerator("RSA");
            keyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
            var keyPair = keyPairGenerator.GenerateKeyPair();

            string publicKey = GenetatePKCSPublicKey(keyPair);
            string privateKey = GenetatePKCS1PrivateKey(keyPair);

            return new KeyValuePair<string, string>(publicKey, privateKey);
        }

        /// <summary>
        /// 生成RSA2密钥(PKCS8)
        /// 返回值中Key为公钥，Value为私钥
        /// </summary>
        /// <returns></returns>
        public static KeyValuePair<string, string> GenerateRSA2KeysWithPKCS8()
        {
            IAsymmetricCipherKeyPairGenerator keyPairGenerator = GeneratorUtilities.GetKeyPairGenerator("RSA");
            keyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
            var keyPair = keyPairGenerator.GenerateKeyPair();

            string publicKey = GenetatePKCSPublicKey(keyPair);
            string privateKey = GenetatePKCS8PrivateKey(keyPair);

            return new KeyValuePair<string, string>(publicKey, privateKey);
        }

        /// <summary>
        /// 将PKCS1私钥转为PKCS8
        /// </summary>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string ConvertPKCS1ToPKCS8(string privateKey)
        {
            PemReader pemReader = new PemReader(new StringReader(privateKey));

            AsymmetricCipherKeyPair keyPair = pemReader.ReadObject() as AsymmetricCipherKeyPair;
            using (StringWriter sw = new StringWriter())
            {
                PemWriter pemWriter = new PemWriter(sw);
                Pkcs8Generator pkcs8Generator = new Pkcs8Generator(keyPair.Private);
                pemWriter.WriteObject(pkcs8Generator);
                pemWriter.Writer.Close();
                return sw.ToString();
            }
        }

        #region Private Function
        /// <summary>
        /// 生成PKCS公钥
        /// </summary>
        /// <param name="asymmetricCipherKeyPair"></param>
        /// <returns></returns>
        private static string GenetatePKCSPublicKey(AsymmetricCipherKeyPair asymmetricCipherKeyPair)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                PemWriter pemWriter = new PemWriter(stringWriter);
                pemWriter.WriteObject(asymmetricCipherKeyPair.Public);
                pemWriter.Writer.Close();
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// 生成PKSC8私钥
        /// </summary>
        /// <param name="asymmetricCipherKeyPair"></param>
        /// <returns></returns>
        private static string GenetatePKCS8PrivateKey(AsymmetricCipherKeyPair asymmetricCipherKeyPair)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                PemWriter pemWriter = new PemWriter(stringWriter);
                Pkcs8Generator pkcs8Generator = new Pkcs8Generator(asymmetricCipherKeyPair.Private);

                pemWriter.WriteObject(pkcs8Generator);
                pemWriter.Writer.Close();
                return stringWriter.ToString();
            }
        }

        /// <summary>
        /// 生成PKSC1私钥
        /// </summary>
        /// <param name="asymmetricCipherKeyPair"></param>
        /// <returns></returns>
        private static string GenetatePKCS1PrivateKey(AsymmetricCipherKeyPair asymmetricCipherKeyPair)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                PemWriter pemWriter = new PemWriter(stringWriter);
                pemWriter.WriteObject(asymmetricCipherKeyPair.Private);
                pemWriter.Writer.Close();
                return stringWriter.ToString();
            }
        }
        #endregion
    }
}
