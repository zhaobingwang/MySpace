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
        #region Generate Key & Key Converter Using BouncyCastle

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
            privateKey = $"-----BEGIN RSA PRIVATE KEY-----\n{privateKey}\n-----END RSA PRIVATE KEY-----";
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

        #region Encryptiton Function
        /// <summary>
        /// RSA OpenSSL 公钥加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText, string publicKey)
        {
            var rsa = CreateRsaFromPublicKey(publicKey);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var cipherBytes = rsa.Encrypt(plainTextBytes, RSAEncryptionPadding.Pkcs1);
            var cipher = Convert.ToBase64String(cipherBytes);
            return cipher;
        }

        /// <summary>
        /// RSA OpenSSL 私钥解密
        /// </summary>
        /// <param name="cipher"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public static string Decrypt(string cipher, string privateKey)
        {
            var rsa = CreateRsaFromPrivateKey(privateKey);
            var cipherBytes = System.Convert.FromBase64String(cipher);
            var plainTextBytes = rsa.Decrypt(cipherBytes, RSAEncryptionPadding.Pkcs1);
            var plainText = Encoding.UTF8.GetString(plainTextBytes);
            return plainText;
        }

        private static RSA CreateRsaFromPrivateKey(string privateKey)
        {
            var privateKeyBits = System.Convert.FromBase64String(privateKey);
            var rsa = RSA.Create();
            var RSAparams = new RSAParameters();

            using (var binr = new BinaryReader(new MemoryStream(privateKeyBits)))
            {
                byte bt = 0;
                ushort twobytes = 0;
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130)
                    binr.ReadByte();
                else if (twobytes == 0x8230)
                    binr.ReadInt16();
                else
                    throw new Exception("Unexpected value read binr.ReadUInt16()");

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102)
                    throw new Exception("Unexpected version");

                bt = binr.ReadByte();
                if (bt != 0x00)
                    throw new Exception("Unexpected value read binr.ReadByte()");

                RSAparams.Modulus = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.Exponent = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.D = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.P = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.Q = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.DP = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.DQ = binr.ReadBytes(GetIntegerSize(binr));
                RSAparams.InverseQ = binr.ReadBytes(GetIntegerSize(binr));
            }

            rsa.ImportParameters(RSAparams);
            return rsa;
        }
        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();
            else
                if (bt == 0x82)
            {
                highbyte = binr.ReadByte();
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            return count;
        }
        private static RSA CreateRsaFromPublicKey(string publicKeyString)
        {
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] x509key;
            byte[] seq = new byte[15];
            int x509size;

            x509key = Convert.FromBase64String(publicKeyString);
            x509size = x509key.Length;

            using (var mem = new MemoryStream(x509key))
            {
                using (var binr = new BinaryReader(mem))
                {
                    byte bt = 0;
                    ushort twobytes = 0;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130)
                        binr.ReadByte();
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();
                    else
                        return null;

                    seq = binr.ReadBytes(15);
                    if (!CompareBytearrays(seq, SeqOID))
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8103)
                        binr.ReadByte();
                    else if (twobytes == 0x8203)
                        binr.ReadInt16();
                    else
                        return null;

                    bt = binr.ReadByte();
                    if (bt != 0x00)
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130)
                        binr.ReadByte();
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();
                    else
                        return null;

                    twobytes = binr.ReadUInt16();
                    byte lowbyte = 0x00;
                    byte highbyte = 0x00;

                    if (twobytes == 0x8102)
                        lowbyte = binr.ReadByte();
                    else if (twobytes == 0x8202)
                    {
                        highbyte = binr.ReadByte();
                        lowbyte = binr.ReadByte();
                    }
                    else
                        return null;
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                    int modsize = BitConverter.ToInt32(modint, 0);

                    int firstbyte = binr.PeekChar();
                    if (firstbyte == 0x00)
                    {
                        binr.ReadByte();
                        modsize -= 1;
                    }

                    byte[] modulus = binr.ReadBytes(modsize);

                    if (binr.ReadByte() != 0x02)
                        return null;
                    int expbytes = (int)binr.ReadByte();
                    byte[] exponent = binr.ReadBytes(expbytes);

                    var rsa = RSA.Create();
                    var rsaKeyInfo = new RSAParameters
                    {
                        Modulus = modulus,
                        Exponent = exponent
                    };
                    rsa.ImportParameters(rsaKeyInfo);
                    return rsa;
                }

            }
        }
        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }
        #endregion
    }

    #region RSA Data Structure
    /// <summary>
    /// RSA密钥
    /// </summary>
    public class RsaKeys
    {
        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey { get; set; }
    }

    /// <summary>
    /// 密钥大小
    /// </summary>
    public enum RSAKeySize
    {
        /// <summary>
        /// 长度为512
        /// </summary>
        Key512 = 512,

        /// <summary>
        /// 长度为1024
        /// </summary>
        Key1024 = 1024,

        /// <summary>
        /// 长度为2048
        /// </summary>
        Key2048 = 2048,

        /// <summary>
        /// 长度为4096
        /// </summary>
        Key4096 = 4096
    }
    #endregion
}
