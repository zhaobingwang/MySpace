using MySpace.WeChat.OfficialAccounts;
using MySpace.WeChat.OfficialAccounts.Domain;
using MySpace.WeChat.OfficialAccounts.Request;
using System.Threading.Tasks;
using Xunit;

namespace MySpace.WeChat.IntegrationTests.OfficialAccounts
{
    [Trait("微信", "公众号")]
    public class GetUserInfo : WeChatConfig
    {
        [Fact(DisplayName = "获取单个用户信息-返回成功-正常入参")]
        public async Task GetUserInfo_ShouldSuccess_WithExpectedParameters()
        {
            GetUserInfoModel model = new GetUserInfoModel
            {
                OpenID = OpenID
            };

            IWeChatClient client = new DefaultClient(ServerUrl, AppId, AppSecret);

            var requestToken = new GetAccessTokenReqeust();
            var resultToken = await client.GetAccessToken(requestToken);
            var token = resultToken.AccessToken;

            var request = new GetUserInfoRequest();
            request.Parameters = model;
            var result = await client.Execute(request, token);
            Assert.True(result.ErrorCode == 0);
        }
    }
}
