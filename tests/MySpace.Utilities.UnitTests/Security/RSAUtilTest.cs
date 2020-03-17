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

        [Fact(DisplayName = "将PKCS1私钥转为PKCS8")]
        public void ConvertPKCS1ToPKCS8Success()
        {
            var result = RSAUtil.ConvertPKCS1ToPKCS8("MIIEpQIBAAKCAQEAhWo+Maatx3Z6d+xQmnKYt4Xc3yA48mVJY2e0IiwRMCyrGUK75MLbSRCtzBrcIc/RtkhItSr1HJh7pmscrgQ5KkIA3vtPfkJuFEPSv9WAp+g9PgXc1lHXMk9bpb0D5kk12SRDGdWFcww61HW/Zm44DHVDRTm8E+Xjje7WjzRjQ3ztkYoQCwcLVFTfjfv/DCt0la1iLNLIgxi1myDJ0zv/geII2r37myzYUVMsgKehDdXc1h56u2aOuGRg5UkiSCKB4iRi4U9b03kPZwMLQPzzRpM8mpJ0iWRhq7+OxULeMTnBDWDAwna+O4VkHTU8q64HTdtAGEVc8+j95WH/lDaTHwIDAQABAoIBACgyQenQt8QEeNKf8wsNouCMZucc/Ltfc/SMvrObBlS26JgUSKscYFhLu6lmoFNZm2wprCpVdoM2l+6kkAAICrcmKsAEBMfcOPFHG/yrVXeBW85PkuFJyCYCzfCKGd4syZoSOFtUvz/R+/mePlwcsitiuzFkuztdhKlzP9bmqE+hKS5xrAXYA12iGnic+kOdSDEnzpBRsZAqd8BbMn5tKVfFvAYNh7e2PyzVmgGr/oCqrc0w6qB05D8rMyZNORzOkti79gLZ4HXM+CCpUxuTB/Zmpb7j3YL0NTqOJutkMXeIz9fu/n/PsAuItz9bYcQalh1HR/1rf8PpOGe1RxCBOLkCgYEAwfesVp8CQimqlG3TFkvCZRVfHtu+en/LP69G52HPnt2sHFsO3s4dFZhjbhbnuUpIaMJgvizffyqqABizaeehKHrY1uxS+3s9nzU0eU9u5ZtcrWDFVT2A/b27thASARvBPPikcl/tqagBdsJCZPmp2XWIN8NJozD9fgptxMx/55cCgYEAsBUS/3ISp9aZxlQ6Up9XtZ2lPf4yhWoBF2v9vBJUZto/Z2PcSRRr2IqaQTnnAWTAEbGtfmkn4dhFWHnCfUnnp2WWEp0aq+VRaIl7s3CdytrLDU2hN7Y7C1Ey25yCtPX2Vg8B1O52zTbP9o84wtdlci2+1t/bmjz8QlFkqjQ4YbkCgYEAsaCOQgT7nHtrquGoHRLjwo3/vdKebK/7AScSV3JLH8EAjDcXNxKpr80NwRNYwWY1STo4Pe/5/AqmA9Ca/LER9HALg0aH96S0mcevdig39iyAgoXMMHNSXQwTinbNBhbUr3FDpzoR+vvP22GqS64WzP3E8Mv182w5t+L1AvQDbaECgYEAmhHWja1CpZkg9Gi+n4zNMhy+eX/ytMoMKnJTkjx3nYdZ8x1tooQ72T1tu6TufEmrxc+x/uoD+5lBFCl2BCqmh9Jbfe35aG8+zDmAA4KGjvjissE6T4UkJMLnvUE1HSIaaTK4Z5hAW0+aqCKph9Lw8PcWBO3bORojn+OYMVWAAAECgYEAlU+1LmJKvMIj1e/9EXQ2MpxAhJEYfluBOLbK3sot2+GrRtMv7IiaGMbCJ7ro0MjtoJUSArzWCikgoaOdG6t5r1zg9BGlsLAYlmMSJEAc2eTMgV0scOZiZUQTwKDSdtb1HOCWMmfA5G47pLQmS/GK+N0pASr+q5PE7K656vrwQ+4=");
            Assert.NotNull(result);
        }
    }
}
