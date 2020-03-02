using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MySpace.WeChat.OfficialAccounts.Response
{
    public class GetUserListResponse : WeChatResponse
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("data")]
        public UserListData Data { get; set; }
    }

    public class UserListData
    {
        [JsonPropertyName("openid")]
        public List<string> OpenIDs { get; set; }

        [JsonPropertyName("next_openid")]
        public string NextOpenID { get; set; }
    }
}
