using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.WeChat.Request
{
    public class GetUserInfoRequest : IWeChatRequest<WeChatResponse>
    {
        public HttpMethod HttpMethod => HttpMethod.Get;

        public IDictionary<string, string> GetRequestParameters { get; set; }
        public string PostRequestJsonData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetApiName()
        {
            return "user/info";
        }
    }
}
