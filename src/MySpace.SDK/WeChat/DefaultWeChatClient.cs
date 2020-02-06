using MySpace.Utilities.Webs;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System;

namespace MySpace.SDK.WeChat
{
    public class DefaultWeChatClient : IWeChatClient
    {
        public const string APP_ID = "appid";
        public const string APP_SECRET = "secret";
        public const string GRANT_TYPE = "grant_type";
        private readonly string serverUrl;
        private string charset;
        WebUtils webUtils;

        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public DefaultWeChatClient(string serverUrl, string appId, string appSecret)
        {
            this.serverUrl = serverUrl;
            AppId = appId;
            AppSecret = appSecret;
            webUtils = new WebUtils(serverUrl);
        }
        public Task<T> Execute<T>(IWeChatRequest<T> request, string accessToken) where T : WeChatResponse
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAccessToken<T>(IWeChatRequest<T> request, string grantType = null) where T : WeChatResponse
        {
            if (string.IsNullOrEmpty(charset))
                charset = "utf-8";
            if (string.IsNullOrEmpty(grantType))
                grantType = "client_credential";
            var txtParams = new Dictionary<string, string>();
            txtParams.Add(GRANT_TYPE, grantType);
            txtParams.Add(APP_ID, AppId);
            txtParams.Add(APP_SECRET, AppSecret);

            var url = $"{serverUrl}/{request.GetApiName()}";
            var resp = await webUtils.GetAsync(url, txtParams, charset);
            Console.WriteLine(resp);
            var result = JsonSerializer.Deserialize<T>(resp);
            return result;
        }
    }
}
