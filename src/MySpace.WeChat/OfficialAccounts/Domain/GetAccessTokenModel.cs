using System.Text.Json.Serialization;

namespace MySpace.WeChat.OfficialAccounts.Domain
{
    public class GetAccessTokenModel : WeChatReqeustParamsObject
    {
        [JsonPropertyName("openid")]
        public string OpenID { get; set; }

        [JsonPropertyName("lang")]
        public string Language { get; set; } = "zh_CN";
    }
}
