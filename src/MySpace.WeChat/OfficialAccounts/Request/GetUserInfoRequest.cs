using MySpace.WeChat.OfficialAccounts.Domain;
using MySpace.WeChat.OfficialAccounts.Response;

namespace MySpace.WeChat.OfficialAccounts.Request
{
    public class GetUserInfoRequest : IWeChatRequest<GetUserInfoResponse, GetUserInfoModel>
    {
        public HttpMethod HttpMethod => HttpMethod.Get;
        public GetUserInfoModel Parameters { get; set; }

        public string GetApiName()
        {
            return "user/info";
        }
    }
}