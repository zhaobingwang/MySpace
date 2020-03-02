using MySpace.SDK.WeChat.Domain;
using MySpace.SDK.WeChat.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.SDK.WeChat.Request
{
    public class GetUserInfoRequest : IWeChatRequest<GetUserInfoResponse, GetUserInfoModel>
    {
        public HttpMethod HttpMethod => HttpMethod.Get;
        public GetUserInfoModel Parameters { get; set; }

        public string GetApiName()
        {
            return "user/info";
        }
    }
}