using MySpace.SDK.Models.Message;
using MySpace.SDK.Services.Message;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MySpace.SDK.Services
{
    public class WeChatMessageService : BaseMessage
    {
        /// <summary>
        /// 基础地址
        /// </summary>
        private const string WE_CHAT_API_URL_FOUNDATION = "https://api.weixin.qq.com/cgi-bin/";

        /// <summary>
        /// 获取access_token接口名
        /// </summary>
        private const string WE_CHAT_API_NAME_GET_ACCESS_TOKEN = "token";

        /// <summary>
        /// 模板消息接口名
        /// </summary>
        private const string WE_CHAT_API_NAME_TEMPLATE_MESSAGE = "message/template/send";

        public override string Url { get; set; }
        public WeChatMessageService(string appId, string appSecret, string grantType = "client_credential") : base(appId, appSecret, grantType)
        {
        }

        public override WeChatGetAccessTokenResponse GetAccessToken()
        {
            Url = $"{WE_CHAT_API_URL_FOUNDATION}{WE_CHAT_API_NAME_GET_ACCESS_TOKEN}?appid={AppId}&secret={AppSecret}&grant_type={GrantType}";
            var result = base.GetAccessToken();
            if (!string.IsNullOrEmpty(result))
            {
                return JsonSerializer.Deserialize<WeChatGetAccessTokenResponse>(result);
            }
            return null;
        }
    }
}
