using System.Text.Json.Serialization;

namespace MySpace.WeChat.OfficialAccounts.Response
{
    public class MessageTemplateSendResponse : WeChatResponse
    {
        [JsonPropertyName("msgid")]
        public long MessageId { get; set; }
    }
}
