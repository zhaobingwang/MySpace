using MySpace.SDK.WeChat;
using MySpace.SDK.WeChat.Domain;
using MySpace.SDK.WeChat.Request;
using MySpace.SDK.WeChat.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MySpace.SDK.IntegrationTests.WeChat
{
    [Trait("微信", "公众号")]
    public class GetAccessToken : WeChatConfig
    {
        [Fact(DisplayName = "获取AccessToken成功")]
        public async Task GetTokenShouldSuccess()
        {
            IWeChatClient client = new DefaultWeChatClient(ServerUrl, AppId, AppSecret);
            var request = new GetAccessTokenReqeust();
            var result = await client.GetAccessToken(request);

            Assert.NotNull(result.AccessToken);
            Assert.True(result.ExpiresIn > 0);
        }
    }
}
