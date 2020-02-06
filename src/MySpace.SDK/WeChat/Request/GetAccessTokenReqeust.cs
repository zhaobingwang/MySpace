using MySpace.SDK.WeChat.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.WeChat.Request
{
    /// <summary>
    /// 微信公众号 API:获取Access Token
    /// </summary>
    public class GetAccessTokenReqeust : IWeChatRequest<GetAccessTokenResponse>
    {
        public string GetApiName()
        {
            return "token";
        }

        public string GetParameters()
        {
            return string.Empty;
        }
    }
}