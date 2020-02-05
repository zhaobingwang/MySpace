using Microsoft.Extensions.Configuration;
using MySpace.SDK.Models.Message;
using MySpace.SDK.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace MySpace.SDK.IntegrationTests.Services.Message
{
    [Trait("消息", "微信")]
    public class WeChatGetToken : BaseTest<WeChatGetToken>
    {
        private string appId;
        private string appSecret;
        public WeChatGetToken()
        {
            appId = Configuration.GetSection("WeChat:Foundation:AppId").Value;
            appSecret = Configuration.GetSection("WeChat:Foundation:AppSecret").Value;
        }

        [Fact(DisplayName = "获取AccessToken")]
        public void GetTokenShouldSuccess()
        {
            WeChatMessageService weChatMessageService = new WeChatMessageService(appId, appSecret);
            var result = (WeChatGetAccessTokenResponse)weChatMessageService.GetAccessToken();
            Assert.NotNull(result.AccessToken);
            Assert.True(result.ExpiresIn > 0);
        }
    }
}
