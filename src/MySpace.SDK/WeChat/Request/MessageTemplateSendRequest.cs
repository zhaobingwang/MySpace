using MySpace.SDK.WeChat.Domain;
using MySpace.SDK.WeChat.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MySpace.SDK.WeChat.Request
{
    public class MessageTemplateSendRequest<TTemplate> : IWeChatRequest<MessageTemplateSendResponse, MessageTemplateSendModel<TTemplate>>
        where TTemplate : class
    {
        public HttpMethod HttpMethod => HttpMethod.Post;

        public MessageTemplateSendModel<TTemplate> Parameters { get; set; }

        public string GetApiName()
        {
            return "message/template/send";
        }
    }
}
