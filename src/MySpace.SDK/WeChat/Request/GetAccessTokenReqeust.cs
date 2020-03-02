using MySpace.SDK.WeChat.Domain;
using MySpace.SDK.WeChat.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.WeChat.Request
{
    /// <summary>
    /// 微信公众号 API:获取Access Token
    /// </summary>
    public class GetAccessTokenReqeust : IWeChatRequest<GetAccessTokenResponse, GetAccessTokenModel>
    {
        public HttpMethod HttpMethod => HttpMethod.Get;

        public GetAccessTokenModel Parameters { get; set; }

        public string GetApiName()
        {
            return "token";
        }
    }
}