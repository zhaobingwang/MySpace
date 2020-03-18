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
        private static readonly string _privateKey = "MIIEowIBAAKCAQEAhk5KGiimA/Q6P/O1w4aMSTH6sa28m5kzZbiXjE9QdGD7dFjiRQCTvdDB+QK0Fb8Ofy1JGcQ2dgZ7ZAWPQXwzsc3GBMHa7d2+EwDYknZb0u2UhziioMZHOGe8J/qJBHiJEaYXKfFv9DnyuIipOSgKLJFPANGsBtBHb/fvw3yu/scft/35x8UDanJmn+VYJblJWCupkQnJQyRRyu8ms0zTYDyUT+P/nz2UZElXUZMGP57Pb2O/UZOsF96NV82HoV1CzjQGF9UV9EpP6fwjzBN92L1f6rfOhgfKejjzuyt6hdHw3TvEAVF7mD4zPgbPA/lSUM3xpQncEMih1fVI/QO1iQIDAQABAoIBAAyYVvaxDTCdvMC2mDsn6QwMNdhn1KI68cj+UKgF4COp3KsCkuWpsjFA3I//oufPLQrcMljKP9k9rmCo7NBVV3u7MnDLxT49Z0/c6nKByway5RTxSL8PGSq+/7Q4GJVkwGX5T37Nd5RNwudvWX9Us++OCPyorRtOeQSVGdUZYkfePGIt1Zx8Yp3scd8IJcVPTbTxh5qdcX6846vjnnNZqq3EX1rVaPUMPEpiKQNkt6CqumTBYPLqT2XDU9CCT4x0841fdQrgbUbXHl/Qc3mbWfuuQjI33D5jDnl35xBIt2jxlRLAH9kj2oTXz5YBX/uWX6N+vZVzLqXkfNMUmKDJDgECgYEA+HJvJh17HOxc+xCYq5GzKgdGV8IVN9WfMGzzMLjyb5O2sQgsTXem4DYwhqiKbqdU6X7PdbrtxfcfSD6o68z8sZVAdruVt6j+pWnJXnZqHULQgapzblGc3lZx1FGfc2nHBiGLRYKAmrqV4DeHNnmH7LbnIIDkeHpNepqaEfYIXykCgYEAimOKAPhuF7awC4eNHqWj3KkmG+c8tOihb/nL4QcYE66SgO23CcYSG57f8SsV9kGiqJCJYvwQBJ1tJcgqBW4ObU3RuGqZKoIYNyqGcJwasNmPUgbd49F6oaRjDL5x9zZTedbhdAeIqoVsKMv6OR12rWqmtaRn3QDmK/+RCvvqT2ECgYEAot/CZiZlk2yQ+DbFH5UA88iZIOcnqdbt6X1DYOmeZe9ckWpeQNr0F4DvBxhuyGQCkqCDuRa20lVTuLT7YLqd3n2OKUiIukKbzi0vyjGvF0e6EYeA7Q2r3UamkR6BfdQWmbpb51HKpaU0pC1DAz9hEJpHo1NcdG8ZZAr+fk/g5SECgYAjJ3X/GRyeWYIO67gleN5PR4iuvebl7dJUp5fq6epr1YTRy5Ebon0nFwy8Lr29eJ7hQxYjVvSat4LqfhZumq5/ha0os6uE6NdN7DeKk50UH7AQnj3viV8lgKTIr/gzXFGIOdW7q85DwvDezDIcICftlZITwlfABGJz+s/VgnjbAQKBgEn8YUMGb/VfFvg6rvf0rSjsrCEkQeUTXoc5lg4woyQWuDoqV1Yd89/Qy6iMEJCwLZuGFfhhVjVPpMtyKNflOBZG3T7y8MRKwgKibzUr+pbdPNWMzh1nQbuK/5rZiwmwo/ACp4pHDrdf7A3JONvNQNq282XnQhMaNugNcMuuNwiB";
        private static readonly string _publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhk5KGiimA/Q6P/O1w4aMSTH6sa28m5kzZbiXjE9QdGD7dFjiRQCTvdDB+QK0Fb8Ofy1JGcQ2dgZ7ZAWPQXwzsc3GBMHa7d2+EwDYknZb0u2UhziioMZHOGe8J/qJBHiJEaYXKfFv9DnyuIipOSgKLJFPANGsBtBHb/fvw3yu/scft/35x8UDanJmn+VYJblJWCupkQnJQyRRyu8ms0zTYDyUT+P/nz2UZElXUZMGP57Pb2O/UZOsF96NV82HoV1CzjQGF9UV9EpP6fwjzBN92L1f6rfOhgfKejjzuyt6hdHw3TvEAVF7mD4zPgbPA/lSUM3xpQncEMih1fVI/QO1iQIDAQAB";

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

        [Fact(DisplayName = "将PKCS1私钥转为PKCS8")]
        public void ConvertPKCS1ToPKCS8Success()
        {
            var result = RSAUtil.ConvertPKCS1ToPKCS8("MIIEogIBAAKCAQEAhGrG40YhkynqfvPl+Bf1vDeaLe9qdxGEL2TVQ6b+JpJWJ/PnE0sLt2z57McStE3BmB+4Q6IE0QdgqUDwXDDQoUrNyeOCwk4IgyyxikFfZKWtOhRmdCfPl6w5NeGYnWhwJrovBYnQIloPtm/+hk1faCJvKmR5ILgSVub7JvzBCja408ONt9AxIrij3dlpFdgieyZyuVVZifKjKeiBkoRZIhmPUU7YSOMYpFibqS3Q/CjWrMe8w9eJhzf8xuYdYUKL+qPejv3/Oq9jcJY0UCEnDwbF3whK2lS5ZYZcDTUifJU7KGGmBwlC1FFAyWXx8cbXD+XXqmrSeBXQoq593wsBywIDAQABAoIBADRr9Srag8Y37N6vfdZW3fDSblZLFvHmXFdK6ubqgGkSu8r7UvqfVhcarGKhePUqZz7rJ86WoKOD8S9wRveoV5/S9l87k3OK4vHTSsH6GWLF+CsrElhfvl5ETy3Wjs2aH/Qk9yKRKXXAA8Js2e2fSer23t2AgzeBx7jhnoITw/RfnX0YfAE9IRCBu5P1NKYzpr+NfsCn1y/hdNNUMAqsVt97kT2av7eQ/i772NLpfSIReMhehJzwZ86BJqPNkn0Lwn85+n0fdW9q2H/QufLh+j32J+Ep8liURNaO2WqZ1EdyPqadLzLFhBwvoLU8Fbe7Xul/N3CWMkQIFAkHYg8gHBECgYEAxGDqt0yrofGsHockkMjcfZqSEMrBuU4/ypO+uGT7UmpxpCRdm1K2U3mKZJ/ieADfAjRpcsiCJEuXGTwRZEILwd8KWOM6P9Q0AJ5ST9kK3Nl17PaCn9Fv9WV+eNWY/0SDijkSIq7e+TZlFMJQauzbGo/1KCSdhimEdcMKSjR+QLMCgYEArJ6ZAbzNDjkpXwcwsJoFkh43bqEa01FKi2surR4PXEQq/C9C3Wf+b+WHYaoLelYl2zN5SQy9I845KkyY9y3u5JnVcAMHdaVA03d3czIRZQS/7KivJ2dGiKvgxmGfDK4VXFiffLbVDq8flIpi++pqyaTZ+Ozn9dH2rcZ580npFokCgYABfHpKSNpDr4CN+pfcQKjqinDwj5hHvr/c2KFo49rDFOsnQt8yfb3Dg/f4Kv2byuXlLmBd7gaOH8RU/I9lItrT7Mw3QAEA2qpKFuiokgvy//JUiMkUTJF8WfhLEdLGm84jDauFd61YVYEOVyokpQZDfTNtylkm2smV2pQJW7xY4QKBgH1/pOAlgrOnjVOAZ77Ni+VKwKRWzqj5/gdUuo+0PhinmtTUC3nq5Io3xvCTb1rXDRjL2I7qiwxgHyGIpOF4bKmYyhtwqFi492OHBLokmY7nIB4QGZ+9LwOoanfwe3D9k5wa9oD2b/oICh61afea216U0sBuhMosh3qZxQnDH4p5AoGATLFSutKvu/lKNonHg9qIkn39W6YJdyEU55TD71CtpKfbacjYvt3Hhxt8T3tOVx0blf3kOOrk2wmx8GrGdoX/7nkB4yF5LwGHCG0CZIop6yw/0D3nYxUSeetYTUq7afKO/XGZvUjZmrw+/S2xR7yTZ1HjhdC4zk0WZBAHH+OfcBM=");
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "加密解密")]
        public void EncryptAndDecrypt_ShouldSuccess()
        {
            string plainText = "test";
            var cipher = RSAUtil.Encrypt(plainText, _publicKey);
            var decryptPlainText = RSAUtil.Decrypt(cipher, _privateKey);
            Assert.Equal(plainText, decryptPlainText);
        }
    }
}
