using MySpace.WeChat.OfficialAccounts;
using MySpace.WeChat.OfficialAccounts.Domain;
using MySpace.WeChat.OfficialAccounts.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MySpace.WeChat.IntegrationTests.OfficialAccounts
{
    public class GetUserList : WeChatConfig
    {
        [Fact(DisplayName = "获取用户列表-返回成功-正常入参")]
        public async Task GetUserList_ShouldSuccess_WithExpectedParameters()
        {
            GetUserListModel model = new GetUserListModel
            {
                NextOpenID = ""
            };

            IWeChatClient client = new DefaultClient(ServerUrl, AppId, AppSecret);

            var requestToken = new GetAccessTokenReqeust();
            var resultToken = await client.GetAccessToken(requestToken);
            var token = resultToken.AccessToken;

            var request = new GetUserListRequest();
            request.Parameters = model;
            var result = await client.Execute(request, token);
            Assert.True(result.ErrorCode == 0);
        }
    }
}
