using MySpace.SDK.WeChat.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.IntegrationTests.WeChat
{
    public class GetUserInfo
    {
        public void GetUserInfo_ShouldSuccess_WithExpectedParameters()
        {
            GetUserInfoModel model = new GetUserInfoModel
            {
                openid = ""
            };
        }
    }
}
