using System.Text.Json.Serialization;

namespace MySpace.WeChat.OfficialAccounts.Response
{
    public class GetAccessTokenResponse : WeChatResponse
    {
        /// <summary>
        /// 获取到的凭证
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 凭证有效时间
        /// （单位：秒）
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
