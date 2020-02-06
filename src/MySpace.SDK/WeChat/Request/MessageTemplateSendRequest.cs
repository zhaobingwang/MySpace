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
        public string PostJsonData { get; set; }
        public string GetApiName()
        {
            return "message/template/send";
        }
        public string GetParameters()
        {
            return PostJsonData;
        }
    }
}
