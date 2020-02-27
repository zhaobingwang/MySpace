using MySpace.SDK.WeChat.Domain;
using MySpace.SDK.WeChat.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MySpace.SDK.WeChat.Request
{
    public class MessageTemplateSendRequest : IWeChatRequest<MessageTemplateSendResponse>
    {
        public HttpMethod HttpMethod => HttpMethod.Post;

        public IDictionary<string, string> GetRequestParameters { get; set; }
        public string PostRequestJsonData { get; set; }

        public string GetApiName()
        {
            return "message/template/send";
        }
    }
}
