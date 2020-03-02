using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MySpace.WeChat.OfficialAccounts
{
    public class WeChatResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [JsonPropertyName("errcode")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonPropertyName("errmsg")]
        public string ErrorMessage { get; set; }
    }
}
