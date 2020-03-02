using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace MySpace.SDK.WeChat.Domain
{
    public class GetAccessTokenModel : WeChatReqeustParamsObject
    {
        [JsonPropertyName("openid")]
        public string OpenID { get; set; }

        [JsonPropertyName("lang")]
        public string Language { get; set; } = "zh_CN";
    }
}
