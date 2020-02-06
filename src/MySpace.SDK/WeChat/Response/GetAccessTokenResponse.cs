using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MySpace.SDK.WeChat.Response
{
    public class GetAccessTokenResponse : WeChatResponse
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
