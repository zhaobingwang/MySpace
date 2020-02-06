using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MySpace.SDK.WeChat.Response
{
    public class MessageTemplateSendResponse : WeChatResponse
    {
        [JsonPropertyName("msgid")]
        public long MessageId { get; set; }
    }
}
