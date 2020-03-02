using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MySpace.WeChat.OfficialAccounts.Domain
{
    public class GetUserListModel : WeChatReqeustParamsObject
    {
        /// <summary>
        /// 第一个拉取的OPENID，不填默认从头开始拉取。
        /// 一次拉取调用最多拉取10000个关注者的OpenID
        /// </summary>
        [JsonPropertyName("next_openid")]
        public string NextOpenID { get; set; }
    }
}
