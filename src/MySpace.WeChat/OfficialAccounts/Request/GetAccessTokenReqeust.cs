using MySpace.WeChat.OfficialAccounts.Domain;
using MySpace.WeChat.OfficialAccounts.Response;

namespace MySpace.WeChat.OfficialAccounts.Request
{
    /// <summary>
    /// 微信公众号 API:获取Access Token
    /// </summary>
    public class GetAccessTokenReqeust : IWeChatRequest<GetAccessTokenResponse, GetAccessTokenModel>
    {
        public HttpMethod HttpMethod => HttpMethod.Get;

        public GetAccessTokenModel Parameters { get; set; }

        public string GetApiName()
        {
            return "token";
        }
    }
}