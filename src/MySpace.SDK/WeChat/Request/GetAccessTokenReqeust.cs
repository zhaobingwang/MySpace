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
        public HttpMethod HttpMethod => HttpMethod.Get;

        public IDictionary<string, string> GetRequestParameters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string PostRequestJsonData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetApiName()
        {
            return "token";
        }
    }
}