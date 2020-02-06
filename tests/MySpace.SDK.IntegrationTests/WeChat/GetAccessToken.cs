using MySpace.SDK.WeChat;
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
    public class GetAccessToken : BaseTest<GetAccessToken>
    {
        private string appId;
        private string appSecret;
        public GetAccessToken()
        {
            appId = Configuration.GetSection("WeChat:Foundation:AppId").Value;
            appSecret = Configuration.GetSection("WeChat:Foundation:AppSecret").Value;
        }
        [Fact(DisplayName = "获取AccessToken成功")]
        public async Task GetTokenShouldSuccess()
        {
            IWeChatClient client = new DefaultWeChatClient("https://api.weixin.qq.com/cgi-bin", appId, appSecret);
            var request = new GetAccessTokenReqeust();
            var result = await client.GetAccessToken(request);
            Assert.NotNull(result.AccessToken);
            Assert.True(result.ExpiresIn > 0);
        }
    }
}
