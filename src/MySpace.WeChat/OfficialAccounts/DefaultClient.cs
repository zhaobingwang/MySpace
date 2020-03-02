using MySpace.Utilities.Webs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MySpace.WeChat.OfficialAccounts
{
    public class DefaultClient : IWeChatClient
    {
        public const string APP_ID = "appid";
        public const string APP_SECRET = "secret";
        public const string GRANT_TYPE = "grant_type";
        public const string ACCESS_TOKEN = "access_token";
        private readonly string serverUrl;
        private string charset;
        WebUtils webUtils;

        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public DefaultClient(string serverUrl, string appId, string appSecret)
        {
            this.serverUrl = serverUrl;
            AppId = appId;
            AppSecret = appSecret;
            webUtils = new WebUtils(serverUrl);
        }
        public async Task<TResponse> Execute<TResponse, TParameters>(IWeChatRequest<TResponse, TParameters> request, string accessToken)
            where TResponse : WeChatResponse
            where TParameters : WeChatReqeustParamsObject
        {
            if (string.IsNullOrEmpty(charset))
                charset = "utf-8";
            var url = $"{serverUrl}/{request.GetApiName()}?{ACCESS_TOKEN}={accessToken}";

            string resp = string.Empty;
            if (request.HttpMethod == HttpMethod.Post)
            {
                resp = await webUtils.PostAsync(url, JsonSerializer.Serialize(request.Parameters), charset);
            }
            else
            {
                resp = await webUtils.GetAsync(url, request.Parameters.ToDictionary(), charset);
            }

            var result = JsonSerializer.Deserialize<TResponse>(resp);
            return result;
        }

        public async Task<TResponse> GetAccessToken<TResponse, TParameters>(IWeChatRequest<TResponse, TParameters> request, string grantType = null)
            where TResponse : WeChatResponse
            where TParameters : WeChatReqeustParamsObject
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
            var result = JsonSerializer.Deserialize<TResponse>(resp);
            return result;
        }
    }
}
