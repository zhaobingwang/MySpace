using MySpace.WeChat.OfficialAccounts;
using MySpace.WeChat.OfficialAccounts.Request;
using System.Threading.Tasks;
using Xunit;

namespace MySpace.WeChat.IntegrationTests.OfficialAccounts
{
    [Trait("微信", "公众号")]
    public class GetAccessToken : WeChatConfig
    {
        [Fact(DisplayName = "获取AccessToken成功")]
        public async Task GetTokenShouldSuccess()
        {
            IWeChatClient client = new DefaultClient(ServerUrl, AppId, AppSecret);
            var request = new GetAccessTokenReqeust();
            var result = await client.GetAccessToken(request);

            Assert.NotNull(result.AccessToken);
            Assert.True(result.ExpiresIn > 0);
        }
    }
}
