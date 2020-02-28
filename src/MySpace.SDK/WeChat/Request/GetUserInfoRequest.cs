using MySpace.SDK.WeChat.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.WeChat.Request
{
    public class GetUserInfoRequest : IWeChatRequest<GetUserInfoResponse>
    {
        public HttpMethod HttpMethod => HttpMethod.Get;

        public IDictionary<string, string> GetRequestParameters { get; set; }
        public string PostRequestJsonData { get; set; }

        public string GetApiName()
        {
            return "user/info";
        }
    }
}
