using MySpace.SDK.WeChat;
using MySpace.SDK.WeChat.Domain;
using MySpace.SDK.WeChat.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace MySpace.SDK.IntegrationTests.WeChat
{
    [Trait("微信", "公众号")]
    public class GetUserInfo : WeChatConfig
    {
        [Fact(DisplayName = "获取单个用户信息-返回成功-正常入参")]
        public async Task GetUserInfo_ShouldSuccess_WithExpectedParameters()
        {
            GetUserInfoModel model = new GetUserInfoModel
            {
                openid = OpenID,
                lang = "zh_CN"
            };

            IWeChatClient client = new DefaultWeChatClient(ServerUrl, AppId, AppSecret);

            var requestToken = new GetAccessTokenReqeust();
            var resultToken = await client.GetAccessToken(requestToken);
            var token = resultToken.AccessToken;

            var request = new GetUserInfoRequest();
            request.GetRequestParameters = model.ToDictionary();
            var result = await client.Execute(request, token);
            Assert.True(result.ErrorCode == 0);
        }
    }
}
